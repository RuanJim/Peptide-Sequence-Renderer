// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRenderAddin.cs" company="PerkinElmer Inc.">
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
using System.Diagnostics;
using System.Windows.Forms;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Preference;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Data;
using Spotfire.Dxp.Data.Import;
using Spotfire.Dxp.Framework.Preferences;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer
{
    /// <summary>
    /// </summary>
    public sealed class PDRenderAddin : AddIn
    {
        internal const int DefaultMaxAcidAmount = 20;
        internal const int DefaultFontSize = 80;
        internal static string DefaultFontFamily => "Tahoma";

        internal static bool ColorCodeTableLoaded => MonomerColorTable.Count > 0;

        internal static Dictionary<string, ColorSetting> MonomerColorTable { get; } =
            new Dictionary<string, ColorSetting>();

        internal static PDRenderPreference RendererPreference;

        protected override void RegisterValueRenderers(ValueRendererRegistrar registrar)
        {
            base.RegisterValueRenderers(registrar);

            registrar.Register(new Renderer.PDRendererFactory());
        }

        protected override void RegisterPreferences(PreferenceRegistrar registrar)
        {
            base.RegisterPreferences(registrar);

            registrar.Register<Preference.PDRenderPreference>();
        }

        protected override void RegisterViews(ViewRegistrar registrar)
        {
            base.RegisterViews(registrar);

            registrar.Register(typeof(Form), typeof(Models.PDRenderSettings), typeof(Views.PDRendererSettingsDialog));
        }

        protected override void OnAnalysisServicesRegistered(ServiceProvider serviceProvider)
        {
            base.OnUserServicesRegistered(serviceProvider);

            if (!ColorCodeTableLoaded)
            {
                GetMonomerColorTable(serviceProvider);
            }
        }

        internal static void GetMonomerColorTable(IServiceProvider serviceProvider)
        {
            MonomerColorTable.Clear();

            var preferenceManager = (PreferenceManager) serviceProvider.GetService(typeof(PreferenceManager));

            if (preferenceManager == null)
            {
                return;
            }

            RendererPreference = preferenceManager.GetPreference<PDRenderPreference>();

            try
            {
                var informationLinkID = RendererPreference.ColorCodingInformationLinkGuid;

                var informationLinkDescriptor =
                    InformationLinkDataSource.GetInformationLinkDescriptor(new Guid(informationLinkID));

                var informationLinkDataSource =
                    new InformationLinkDataSource(informationLinkDescriptor.Identifier);

                using (var connection = informationLinkDataSource.Connect(serviceProvider, DataSourcePromptMode.None))
                using (var reader = connection.ExecuteQuery2())
                {
                    while (reader.MoveNext())
                    {
                        var monomer = reader.Columns["MONOMER"].Cursor.CurrentDataValue.ValidValue.ToString();

                        if (MonomerColorTable.ContainsKey(monomer))
                        {
                            continue;
                        }

                        var foreColor = reader.Columns["FORE_COLOR"].Cursor.CurrentDataValue.ValidValue.ToString();
                        var backColor = reader.Columns["BACK_COLOR"].Cursor.CurrentDataValue.ValidValue.ToString();

                        MonomerColorTable.Add(monomer, new ColorSetting
                        {
                            ForeColor = foreColor,
                            BackgroundColor = backColor
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                var sourceName = "Peptide Sequence Renderer";

                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Information Link");
                }

                EventLog log = new EventLog
                {
                    Source = sourceName
                };

                log.WriteEntry(ex.Message);
            }
        }
    }
}
