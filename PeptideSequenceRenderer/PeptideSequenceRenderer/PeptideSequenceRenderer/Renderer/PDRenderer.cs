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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application.Visuals.ValueRenderers;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Renderer
{
    public sealed class PDRenderer : CustomValueRenderer
    {
        protected override void RenderCore(ValueRendererSettings rendererSettings, ValueRendererArgs rendererArgs, ValueRendererResult renderingResult)
        {
            PDRenderSettings settings = (PDRenderSettings) rendererSettings;

            int cellHeight = rendererArgs.Height;
            int cellWidth = rendererArgs.Width/settings.MaxAcidAmount;

            int fontSize = settings.FontSize;

            if (rendererArgs.Width == rendererArgs.Height)
            {
                cellHeight = cellWidth;
            }

            Regex regex = new Regex(@"PEPTIDE1\{(.+?)\}");

            string cellValue = rendererArgs.DataValue.ValidValue.ToString();

            if (!cellValue.Contains(".") || !regex.IsMatch(cellValue))
            {
                Bitmap defaultImage = new Bitmap(rendererArgs.Width, rendererArgs.Height);

                using (Graphics g = Graphics.FromImage(defaultImage))
                {
                    g.DrawString(cellValue, new Font("Tahoma", 8), new SolidBrush(Color.Black), 0, 0);
                }

                renderingResult.SetImage(defaultImage);
                renderingResult.SetTooltip("Not a valid peptide sequence.");

                return;
            }

            var match = regex.Match(cellValue);

            List<string> peptideList = new List<string>();
            List<string> linkerList = new List<string>();


            // TODO: Change spliter to "\n"
            string[] linkerStringArray = cellValue.Split(new string[] {"\n"}, StringSplitOptions.None);

            if (linkerStringArray.Length == 2)
            {
                linkerList.AddRange(linkerStringArray[1].Split(new char[] { '.' }));
            }

            string[] monomerArray = match.Groups[1].Captures[0].Value.Split(new char[] {'.'}).ToArray();

            for (var i = 0; i < monomerArray.Length; i++)
            {
                if (i == 0 && monomerArray[0].Contains("_"))
                {
                    string[] saltMonomer = monomerArray[0].Split(new[] {'_'});

                    peptideList.Add(saltMonomer[0] + "-");
                    peptideList.Add(saltMonomer[1]);
                }
                else
                {
                    peptideList.Add(monomerArray[i]);
                }
            }

            int startIndex = peptideList.Count - linkerList.Count;

            for (var i = peptideList.Count - 1; i >= startIndex; i--)
            {
                if (peptideList[i] == linkerList[i - startIndex])
                {
                    peptideList[i] = $"#{peptideList[i]}#";
                }
            }

            Bitmap bitmap = new Bitmap(cellWidth * settings.MaxAcidAmount, cellHeight);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                for (int i = 0; i < peptideList.Count && i < settings.MaxAcidAmount; i++)
                {
                    string monomer = peptideList[i].Replace("[", string.Empty).Replace("]", string.Empty);

                    ColorSetting color = new ColorSetting
                    {
                        ForeColor = settings.DefaultFontColor,
                        BackgroundColor = settings.DefaultBackgroundColor
                    };

                    if (settings.ColorCodeTable.ContainsKey(monomer))
                    {
                        color = settings.ColorCodeTable[monomer];
                    }

                    if (monomer.Contains("(") && monomer.Contains(")"))
                    {
                        color = new ColorSetting
                        {
                            ForeColor = settings.BranchMonomerFontColor,
                            BackgroundColor = settings.BranchMonomerBackgroundColor
                        };
                    }

                    if (monomer.StartsWith("#") && monomer.EndsWith("#"))
                    {
                        color = new ColorSetting
                        {
                            ForeColor = settings.DefaultFontColor,
                            BackgroundColor = settings.DefaultBackgroundColor
                        };
                    }

                    if (monomer.StartsWith("(") && monomer.EndsWith(")"))
                    {
                        monomer = monomer.Replace("(", string.Empty).Replace(")", string.Empty);
                    }

                    monomer = monomer.Replace("#", string.Empty).Replace("#", string.Empty);

                    Rectangle rect = new Rectangle(i * cellWidth, 0, cellWidth, cellHeight);

                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(color.BackgroundColor)), rect);
                    g.DrawRectangle(new Pen(Color.White), rect);

                    FontFamily fontFamily = new FontFamily(settings.FontFamily);

                    fontFamily.GetEmHeight(FontStyle.Regular);
                    float ascent = fontFamily.GetCellAscent(FontStyle.Regular);
                    float descent = fontFamily.GetCellDescent(FontStyle.Regular);

                    float size = Convert.ToSingle(cellWidth) / 3 * (fontSize / 100f) * fontFamily.GetEmHeight(FontStyle.Regular) / (ascent + descent);

                    Font font = new Font(fontFamily, size, FontStyle.Regular);

                    StringFormat sf = new StringFormat();

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;

                    g.DrawString(monomer, font, new SolidBrush(ColorTranslator.FromHtml(color.ForeColor)), rect, sf);
                }

            }

            renderingResult.SetImage(bitmap);
            renderingResult.SetTooltip(rendererArgs.DataValue.ValidValue.ToString());

        }
    }
}
