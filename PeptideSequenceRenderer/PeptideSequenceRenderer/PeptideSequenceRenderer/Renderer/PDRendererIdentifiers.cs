using Com.PerkinElmer.Service.PeptideSequenceRenderer.Properties;
using Spotfire.Dxp.Application.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    internal class PDRendererIdentifiers : CustomTypeIdentifiers
    {
        public static readonly CustomTypeIdentifier PDRendererTypeIdentifier = CreateTypeIdentifier(
            Resources.AddinName, Resources.AddinName, string.Empty);
    }
}
