using System;
using System.Windows.Forms;

using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Extension;

namespace PeptideSequenceRenderer
{
    /// <summary>
    /// </summary>
    public sealed class CustomAddIn : AddIn
    {
        protected override void RegisterValueRenderers(ValueRendererRegistrar registrar)
        {
            base.RegisterValueRenderers(registrar);
        }
    }
}
