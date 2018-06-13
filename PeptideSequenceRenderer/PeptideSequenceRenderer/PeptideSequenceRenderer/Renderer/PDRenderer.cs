// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRenderer.cs" company="PerkinElmer Inc.">
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

using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application.Visuals.ValueRenderers;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRenderer : CustomValueRenderer
    {
        protected override void RenderCore(ValueRendererSettings rendererSettings, ValueRendererArgs args, ValueRendererResult renderingResult)
        {
            renderingResult.SetImage(System.Drawing.Image.FromFile(@"H:\1.png"));
        }
    }
}
