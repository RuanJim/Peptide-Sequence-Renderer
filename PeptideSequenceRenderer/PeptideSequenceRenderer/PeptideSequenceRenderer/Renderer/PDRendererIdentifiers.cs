﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRendererIdentifiers.cs" company="PerkinElmer Inc.">
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

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    internal class PDRendererIdentifiers : CustomTypeIdentifiers
    {
        public static readonly CustomTypeIdentifier PDRendererTypeIdentifier = CreateTypeIdentifier(
            Resources.AddinName, Resources.AddinName, string.Empty);
    }
}
