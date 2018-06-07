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
        protected override void RegisterPreferences(PreferenceRegistrar registrar)
        {
            base.RegisterPreferences(registrar);

            registrar.Register<Preference.PDRenderPreference>();
        }

        protected override void OnUserServicesRegistered(ServiceProvider serviceProvider)
        {
            base.OnUserServicesRegistered(serviceProvider);
        }
    }
}
