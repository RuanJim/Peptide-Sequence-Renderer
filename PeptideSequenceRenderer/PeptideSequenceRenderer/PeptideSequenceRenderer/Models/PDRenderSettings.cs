// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRenderSettings.cs" company="PerkinElmer Inc.">
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
using System.Runtime.Serialization;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Framework.DocumentModel;
using Spotfire.Dxp.Framework.Persistence;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Models
{
    [Serializable]
    [PersistenceVersion(3, 000)]
    public sealed class PDRenderSettings : CustomValueRendererSettings
    {
        private readonly UndoableProperty<string> branchMonomerBackgroundColor;

        private readonly UndoableProperty<string> branchMonomerFontColor;

        private readonly UndoableProperty<string> defaultBackgroundColor;

        private readonly UndoableProperty<string> defaultFontColor;

        private readonly UndoableProperty<int> fontSize;
        private readonly UndoableProperty<int> maxAcidAmount;

        public PDRenderSettings()
        {
            CreateProperty(PropertyNames.MaxAcidAmount, out maxAcidAmount, PDRenderAddin.DefaultMaxAcidAmount);
            CreateProperty(PropertyNames.FontSize, out fontSize, PDRenderAddin.DefaultFontSize);

            // TODO: set these values.

            CreateProperty(PropertyNames.DefaultFontColor, out defaultFontColor, string.Empty);
            CreateProperty(PropertyNames.DefaultBackgroundColor, out defaultBackgroundColor, string.Empty);
            CreateProperty(PropertyNames.BranchMonomerFontColor, out branchMonomerFontColor, string.Empty);
            CreateProperty(PropertyNames.BranchMonomerBackgroundColor, out branchMonomerBackgroundColor, string.Empty);
        }

        internal PDRenderSettings(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            DeserializeProperty<int>(info, context, PropertyNames.MaxAcidAmount, out maxAcidAmount);
            DeserializeProperty<int>(info, context, PropertyNames.FontSize, out fontSize);

            DeserializeProperty<string>(info, context, PropertyNames.DefaultFontColor, out defaultFontColor);
            DeserializeProperty<string>(info, context, PropertyNames.DefaultBackgroundColor, out defaultBackgroundColor);
            DeserializeProperty<string>(info, context, PropertyNames.BranchMonomerFontColor, out branchMonomerFontColor);
            DeserializeProperty<string>(info, context, PropertyNames.BranchMonomerBackgroundColor, out branchMonomerBackgroundColor);
        }

        public int MaxAcidAmount
        {
            get { return maxAcidAmount.Value; }
            set { maxAcidAmount.Value = value; }
        }

        public int FontSize
        {
            get { return fontSize.Value; }
            set { fontSize.Value = value; }
        }

        public string DefaultFontColor
        {
            get { return defaultFontColor.Value; }
            set { defaultFontColor.Value = value; }
        }

        public string DefaultBackgroundColor
        {
            get { return defaultBackgroundColor.Value; }
            set { defaultBackgroundColor.Value = value; }
        }

        public string BranchMonomerFontColor
        {
            get { return branchMonomerFontColor.Value; }
            set { branchMonomerFontColor.Value = value; }
        }

        public string BranchMonomerBackgroundColor
        {
            get { return branchMonomerBackgroundColor.Value; }
            set { branchMonomerBackgroundColor.Value = value; }
        }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            SerializeProperty<int>(info, context, maxAcidAmount);
            SerializeProperty<int>(info, context, fontSize);
            SerializeProperty<string>(info, context, defaultFontColor);
            SerializeProperty<string>(info, context, defaultBackgroundColor);
            SerializeProperty<string>(info, context, branchMonomerFontColor);
            SerializeProperty<string>(info, context, branchMonomerBackgroundColor);
        }

        protected override Trigger GetRenderTriggerCore()
        {
            return Trigger.CreateCompositeTrigger(
                Trigger.CreatePropertyTrigger(this, PropertyNames.MaxAcidAmount),
                Trigger.CreatePropertyTrigger(this, PropertyNames.FontSize),
                Trigger.CreatePropertyTrigger(this, PropertyNames.DefaultFontColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.DefaultBackgroundColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.BranchMonomerFontColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.BranchMonomerBackgroundColor));
        }

        public new class PropertyNames : CustomValueRendererSettings.PropertyNames
        {
            public static readonly PropertyName MaxAcidAmount = CreatePropertyName("MaxAcidAmount");
            public static readonly PropertyName FontSize = CreatePropertyName("FontSize");
            public static readonly PropertyName DefaultFontColor = CreatePropertyName("DefaultFontColor");
            public static readonly PropertyName DefaultBackgroundColor = CreatePropertyName("DefaultBackgroundColor");
            public static readonly PropertyName BranchMonomerFontColor = CreatePropertyName("BranchMonomerFontColor");
            public static readonly PropertyName BranchMonomerBackgroundColor = CreatePropertyName("BranchMonomerBackgroundColor");
        }
    }

}
