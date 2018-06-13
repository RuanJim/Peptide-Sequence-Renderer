// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRendererFactory.cs" company="PerkinElmer Inc.">
//   Copyright (c) 2013 PerkinElmer Inc.,
//     940 Winter Street, Waltham, MA 02451.
//     All rights reserved.
//     This software is the confidential and proprietary information
//     of PerkinElmer Inc. ("Confidential Information"). You shall not
//     disclose such Confidential Information and may not use it in any way,
//     absent an express written license agreement between you and PerkinElmer Inc.
//     that authorizes such use.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#region

using System;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Data;
using Spotfire.Dxp.Framework.Preferences;
using Spotfire.Dxp.Framework.Services;
using Spotfire.Dxp.Framework.Threading;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRendererFactory : CustomValueRendererFactory<PDRenderer, PDRenderSettings>
    {
        public PDRendererFactory() : base(PDRendererIdentifiers.PDRendererTypeIdentifier, null)
        {
        }

        protected override bool SupportsCreateRendererCore => true;

        protected override PDRenderer CreateRendererCore()
        {
            return new PDRenderer();
        }

        protected override PDRenderSettings CreateRendererSettingsCore()
        {
            var settings = new PDRenderSettings();

            var preferenceManager = settings.GetService<PreferenceManager>();

            var preference = preferenceManager.GetPreference<Preference.PDRenderPreference>();

            //TODO: which one has a higher priority? admin preference or personal settings?
            settings.MaxAcidAmount = preference.MaxAminoAcids;

            settings.DefaultFontColor = string.IsNullOrEmpty(preference.DefaultFontColor)
                ? settings.DefaultFontColor
                : preference.DefaultFontColor;

            settings.DefaultBackgroundColor = string.IsNullOrEmpty(preference.DefaultBackgroundColor)
                ? settings.DefaultBackgroundColor
                : preference.DefaultBackgroundColor;

            settings.BranchMonomerFontColor = string.IsNullOrEmpty(preference.BranchMonomerFontColor)
                ? settings.BranchMonomerFontColor
                : preference.BranchMonomerFontColor;

            settings.BranchMonomerBackgroundColor = string.IsNullOrEmpty(preference.BranchMonomerBackgroundColor)
                ? settings.BranchMonomerBackgroundColor
                : preference.BranchMonomerBackgroundColor;

            return settings;
        }

        protected override CachingBehavior GetCachingBehaviorCore()
        {
            return CachingBehavior.Global;
        }

        protected override object GetModelKeyCore(PDRenderSettings settings)
        {
            return $"{settings.MaxAcidAmount},{settings.FontSize},{settings.DefaultFontColor},{settings.DefaultBackgroundColor},{settings.BranchMonomerFontColor},{settings.BranchMonomerBackgroundColor}";
        }

        protected override float GetRendererMatchCore(DataValueProperties dataValueProperties)
        {
            return 25.0f;
        }

        protected override ThreadingModel GetThreadingModelCore()
        {
            return ThreadingModel.CreateDedicatedThreadingModel(Environment.ProcessorCount);
        }
    }
}
