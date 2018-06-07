using System;
using System.Windows.Forms;

using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Extension;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer
{
    /// <summary>
    /// </summary>
    public sealed class PDRenderAddin : AddIn
    {
        protected override void RegisterValueRenderers(ValueRendererRegistrar registrar)
        {
            base.RegisterValueRenderers(registrar);
        }

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
