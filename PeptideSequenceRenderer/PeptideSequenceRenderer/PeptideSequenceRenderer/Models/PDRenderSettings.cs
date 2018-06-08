using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Framework.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Models
{
    public sealed class PDRenderSettings : CustomValueRendererSettings
    {
        private readonly UndoableProperty<int> maxAcidAmount;

        private readonly UndoableProperty<int> fontSize;

        public PDRenderSettings()
        {
            this.CreateProperty(PropertyNames.MaxAcidAmount, out this.maxAcidAmount, PDRenderAddin.DefaultMaxAcidAmount);
            this.CreateProperty(PropertyNames.FontSize, out this.fontSize, PDRenderAddin.DefaultFontSize);
        }

        internal PDRenderSettings(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.DeserializeProperty<int>(info, context, PropertyNames.MaxAcidAmount, out this.maxAcidAmount);
            this.DeserializeProperty<int>(info, context, PropertyNames.FontSize, out this.fontSize);
        }

        public int MaxAcidAmount
        {
            get { return this.maxAcidAmount.Value; }
            set { this.maxAcidAmount.Value = value; }
        }

        public int FontSize
        {
            get { return this.fontSize.Value; }
            set { this.fontSize.Value = value; }
        }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            this.SerializeProperty<int>(info, context, this.maxAcidAmount);
            this.SerializeProperty<int>(info, context, this.fontSize);
        }

        protected override Trigger GetRenderTriggerCore()
        {
            return Trigger.CreateCompositeTrigger(
                Trigger.CreatePropertyTrigger(this, PropertyNames.MaxAcidAmount),
                Trigger.CreatePropertyTrigger(this, PropertyNames.FontSize)); 
        }

        public new class PropertyNames : CustomValueRendererSettings.PropertyNames
        {
            public static readonly PropertyName MaxAcidAmount = CreatePropertyName("MaxAcidAmount");
            public static readonly PropertyName FontSize = CreatePropertyName("FontSize");
        }
    }

}
