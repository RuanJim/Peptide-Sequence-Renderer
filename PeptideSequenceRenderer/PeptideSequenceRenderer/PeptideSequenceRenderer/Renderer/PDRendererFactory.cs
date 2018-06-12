using Spotfire.Dxp.Application.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Preference;
using Spotfire.Dxp.Data;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRendererFactory : CustomValueRendererFactory<PDRenderer, Models.PDRenderSettings>
    {
        public PDRendererFactory() : base(PDRendererIdentifiers.PDRendererTypeIdentifier, null)
        {
        }

        protected override PDRenderSettings CreateRendererSettingsCore()
        {
            return new PDRenderSettings();
        }

        protected override float GetRendererMatchCore(DataValueProperties dataValueProperties)
        {
            return 25.0f;
        }
    }
}
