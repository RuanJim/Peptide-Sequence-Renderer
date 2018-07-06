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
using System.Collections.Generic;
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
        private readonly UndoableProperty<string> _branchMonomerBackgroundColor;

        private readonly UndoableProperty<string> _branchMonomerFontColor;

        private readonly UndoableProperty<string> _defaultBackgroundColor;

        private readonly UndoableProperty<string> _defaultFontColor;

        private readonly UndoableProperty<int> _fontSize;

        private readonly UndoableProperty<string> _fontFamily;

        private readonly UndoableProperty<int> _maxAcidAmount;

        private readonly UndoableProperty<string> _colorTable;

        public PDRenderSettings()
        {
            CreateProperty(PropertyNames.MaxAcidAmount, out _maxAcidAmount, PDRenderAddin.DefaultMaxAcidAmount);
            CreateProperty(PropertyNames.FontSize, out _fontSize, PDRenderAddin.DefaultFontSize);
            CreateProperty(PropertyNames.FontFamily, out _fontFamily, PDRenderAddin.DefaultFontFamily);

            CreateProperty(PropertyNames.DefaultFontColor, out _defaultFontColor, "#000000");
            CreateProperty(PropertyNames.DefaultBackgroundColor, out _defaultBackgroundColor, "#FFFFFF");
            CreateProperty(PropertyNames.BranchMonomerFontColor, out _branchMonomerFontColor, "#000000");
            CreateProperty(PropertyNames.BranchMonomerBackgroundColor, out _branchMonomerBackgroundColor, "#FFFFFF");
            CreateProperty(PropertyNames.ColorCodeTable, out this._colorTable, string.Empty);
        }

        internal PDRenderSettings(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            DeserializeProperty<int>(info, context, PropertyNames.MaxAcidAmount, out _maxAcidAmount);
            DeserializeProperty<int>(info, context, PropertyNames.FontSize, out _fontSize);
            DeserializeProperty<string>(info, context, PropertyNames.FontFamily, out _fontFamily);

            DeserializeProperty<string>(info, context, PropertyNames.DefaultFontColor, out _defaultFontColor);
            DeserializeProperty<string>(info, context, PropertyNames.DefaultBackgroundColor, out _defaultBackgroundColor);
            DeserializeProperty<string>(info, context, PropertyNames.BranchMonomerFontColor, out _branchMonomerFontColor);
            DeserializeProperty<string>(info, context, PropertyNames.BranchMonomerBackgroundColor, out _branchMonomerBackgroundColor);
            DeserializeProperty<string>(info, context, PropertyNames.ColorCodeTable, out _colorTable);
        }

        public int MaxAcidAmount
        {
            get { return _maxAcidAmount.Value; }
            set { _maxAcidAmount.Value = value; }
        }

        public int FontSize
        {
            get { return _fontSize.Value; }
            set { _fontSize.Value = value; }
        }

        public string FontFamily
        {
            get { return _fontFamily.Value; }
            set { _fontFamily.Value = value; }
        }

        public string DefaultFontColor
        {
            get { return _defaultFontColor.Value; }
            set { _defaultFontColor.Value = value; }
        }

        public string DefaultBackgroundColor
        {
            get { return _defaultBackgroundColor.Value; }
            set { _defaultBackgroundColor.Value = value; }
        }

        public string BranchMonomerFontColor
        {
            get { return _branchMonomerFontColor.Value; }
            set { _branchMonomerFontColor.Value = value; }
        }

        public string BranchMonomerBackgroundColor
        {
            get { return _branchMonomerBackgroundColor.Value; }
            set { _branchMonomerBackgroundColor.Value = value; }
        }

        public Dictionary<string, ColorSetting> ColorCodeTable
        {
            get { return null; }
            set
            {
                
            }
        }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            SerializeProperty<int>(info, context, _maxAcidAmount);
            SerializeProperty<int>(info, context, _fontSize);
            SerializeProperty<string>(info, context, _fontFamily);
            SerializeProperty<string>(info, context, _defaultFontColor);
            SerializeProperty<string>(info, context, _defaultBackgroundColor);
            SerializeProperty<string>(info, context, _branchMonomerFontColor);
            SerializeProperty<string>(info, context, _branchMonomerBackgroundColor);
            SerializeProperty<string>(info, context, _colorTable);
        }

        protected override Trigger GetRenderTriggerCore()
        {
            return Trigger.CreateCompositeTrigger(
                Trigger.CreatePropertyTrigger(this, PropertyNames.MaxAcidAmount),
                Trigger.CreatePropertyTrigger(this, PropertyNames.FontSize),
                Trigger.CreatePropertyTrigger(this, PropertyNames.FontFamily),
                Trigger.CreatePropertyTrigger(this, PropertyNames.DefaultFontColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.DefaultBackgroundColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.BranchMonomerFontColor),
                Trigger.CreatePropertyTrigger(this, PropertyNames.BranchMonomerBackgroundColor));
        }

        public new class PropertyNames : CustomValueRendererSettings.PropertyNames
        {
            public static readonly PropertyName MaxAcidAmount = CreatePropertyName("MaxAcidAmount");
            public static readonly PropertyName FontSize = CreatePropertyName("FontSize");
            public static readonly PropertyName FontFamily = CreatePropertyName("FontFamily");
            public static readonly PropertyName DefaultFontColor = CreatePropertyName("DefaultFontColor");
            public static readonly PropertyName DefaultBackgroundColor = CreatePropertyName("DefaultBackgroundColor");
            public static readonly PropertyName BranchMonomerFontColor = CreatePropertyName("BranchMonomerFontColor");
            public static readonly PropertyName BranchMonomerBackgroundColor = CreatePropertyName("BranchMonomerBackgroundColor");
            public static readonly PropertyName ColorCodeTable = CreatePropertyName("ColorCodeTable");
        }
    }

}
