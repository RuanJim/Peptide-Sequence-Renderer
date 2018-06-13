﻿// --------------------------------------------------------------------------------------------------------------------
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
using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Data;
using Spotfire.Dxp.Framework.Threading;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRendererFactory : CustomValueRendererFactory<PDRenderer, PDRenderSettings>
    {
        public PDRendererFactory() : base(PDRendererIdentifiers.PDRendererTypeIdentifier, null)
        {
        }

        protected override bool SupportsCreateRendererCore
        {
            get
            {
                return true;
            }
        }

        protected override PDRenderer CreateRendererCore()
        {
            return new PDRenderer();
        }

        protected override PDRenderSettings CreateRendererSettingsCore()
        {
            return new PDRenderSettings();
        }

        protected override CachingBehavior GetCachingBehaviorCore()
        {
            return CachingBehavior.Global;
        }

        protected override object GetModelKeyCore(PDRenderSettings settings)
        {
            var document = settings.Context.GetService<Document>();

            var table = document.ActiveDataTableReference;

            // All fields that are read in RenderCore must be part of the cache key for the model.
            string partSeparator = " , ";
            return settings.MaxAcidAmount + partSeparator + settings.FontSize;
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
