using Spotfire.Dxp.Application.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Preference;
using Spotfire.Dxp.Data;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRendererFactory : CustomValueRendererFactory<PDRenderer, PDRendererSettings>
    {
        public PDRendererFactory() : base(PDRendererIdentifiers.PDRendererTypeIdentifier, null)
        {
        }

        protected override PDRendererSettings CreateRendererSettingsCore()
        {
            throw new NotImplementedException();
        }

        protected override float GetRendererMatchCore(DataValueProperties dataValueProperties)
        {
            throw new NotImplementedException();
        }
    }
}
