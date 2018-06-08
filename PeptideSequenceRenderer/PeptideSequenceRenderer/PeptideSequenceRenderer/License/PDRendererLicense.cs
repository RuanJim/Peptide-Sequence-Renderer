using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Framework.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.License
{
    public class PDRendererLicense : CustomLicense
    {
        public new sealed class Functions : CustomLicense.Functions
        {
            public static readonly LicensedFunction PeptideSequenceRenderer = CreateLicensedFunction("Peptide Sequence Renderer", "Peptide Sequence Renderer", string.Empty);
        }
    }
}
