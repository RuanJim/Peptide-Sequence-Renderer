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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application.Visuals.ValueRenderers;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRenderer : CustomValueRenderer
    {
        protected override void RenderCore(ValueRendererSettings rendererSettings, ValueRendererArgs rendererArgs, ValueRendererResult renderingResult)
        {
            Regex regex = new Regex(@"PEPTIDE1\{\[.*?_(.*?)\]\.(.*?)\}");

            var match = regex.Match(rendererArgs.DataValue.ValidValue.ToString());

            List<string> peptideList = new List<string>();

            peptideList.Add(match.Groups[1].Captures[0].Value);

            peptideList.AddRange(match.Groups[2].Captures[0].Value.Split(new char[] { '.' }).ToArray());


            Bitmap bitmap = new Bitmap(rendererArgs.Width, rendererArgs.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                for (int i = 0; i < peptideList.Count; i++)
                {
                    string monomer = peptideList[i].Replace("[", string.Empty).Replace("]", string.Empty);

                    var color = PDRenderAddin.MonomerColorTable[monomer];

                    g.DrawRectangle(new Pen(Color.White), i * 20, 0, 20, 20);
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(color.BackgroundColor)), i * 20 + 1, 1, 18, 18);

                    Font GraphicFont = new Font("Courier New", 10);

                    Point point = new Point(i * 20, 0);
                    StringFormat sf = new StringFormat();

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;

                    g.DrawString(monomer, GraphicFont, new SolidBrush(ColorTranslator.FromHtml(color.ForeColor)), point, sf);
                }

            }

            renderingResult.SetImage(bitmap);
            renderingResult.SetTooltip(rendererArgs.DataValue.ValidValue.ToString());

        }
    }
}
