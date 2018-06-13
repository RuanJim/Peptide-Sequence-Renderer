// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRendererLicense.cs" company="PerkinElmer Inc.">
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

using Com.PerkinElmer.Service.PeptideSequenceRenderer.Properties;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Framework.License;

#endregion

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
