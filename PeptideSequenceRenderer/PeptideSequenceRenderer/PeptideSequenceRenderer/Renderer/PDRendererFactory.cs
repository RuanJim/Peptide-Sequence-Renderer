using Spotfire.Dxp.Application.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Preference;
using Spotfire.Dxp.Data;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;
using Spotfire.Dxp.Framework.Threading;
using Spotfire.Dxp.Application;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRendererFactory : CustomValueRendererFactory<PDRenderer, Models.PDRenderSettings>
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
