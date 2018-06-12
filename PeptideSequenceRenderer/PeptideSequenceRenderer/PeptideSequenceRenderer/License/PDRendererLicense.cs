using Com.PerkinElmer.Service.PeptideSequenceRenderer.Properties;
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
            public static readonly LicensedFunction PeptideSequenceRenderer = CreateLicensedFunction("DC037E0C-C0C6-42A9-9982-C52DF7C19543", Resources.AddinName, string.Empty);
        }
    }
}
