using System;
using System.Windows.Forms;

using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application.Visuals;
using Spotfire.Dxp.Data;
using Spotfire.Dxp.Framework.Persistence;
using Spotfire.Dxp.Framework.Preferences;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer
{
    /// <summary>
    /// </summary>
    public sealed class PDRenderAddin : AddIn
    {
        public const int DefaultMaxAcidAmount = 20;
        public const int DefaultFontSize = 12;

        protected override void RegisterValueRenderers(ValueRendererRegistrar registrar)
        {
            base.RegisterValueRenderers(registrar);
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

        protected override void OnUserServicesRegistered(ServiceProvider serviceProvider)
        {
            base.OnUserServicesRegistered(serviceProvider);
        }
    }
}
