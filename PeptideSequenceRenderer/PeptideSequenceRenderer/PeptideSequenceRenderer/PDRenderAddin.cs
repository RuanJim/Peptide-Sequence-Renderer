// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRenderAddin.cs" company="PerkinElmer Inc.">
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

using System.Windows.Forms;
using Spotfire.Dxp.Application.Extension;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer
{
    /// <summary>
    /// </summary>
    public sealed class PDRenderAddin : AddIn
    {
        public const int DefaultMaxAcidAmount = 20;
        public const int DefaultFontSize = 12;

        protected override void RegisterValueRenderers(ValueRendererRegistrar registrar)
        {
            base.RegisterValueRenderers(registrar);

            registrar.Register(new Renderer.PDRendererFactory());
        }

        protected override void RegisterPreferences(PreferenceRegistrar registrar)
        {
            base.RegisterPreferences(registrar);

            registrar.Register<Preference.PDRenderPreference>();
        }

        protected override void RegisterViews(ViewRegistrar registrar)
        {
            base.RegisterViews(registrar);

            registrar.Register(typeof(Form), typeof(Models.PDRenderSettings), typeof(Views.PDRendererSettingsDialog));
        }

        protected override void OnUserServicesRegistered(ServiceProvider serviceProvider)
        {
            base.OnUserServicesRegistered(serviceProvider);
        }
    }
}
