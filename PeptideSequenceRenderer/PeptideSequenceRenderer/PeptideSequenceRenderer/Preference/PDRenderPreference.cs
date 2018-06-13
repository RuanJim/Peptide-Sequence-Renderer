// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRenderPreference.cs" company="PerkinElmer Inc.">
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

using Com.PerkinElmer.Service.PeptideSequenceRenderer.Properties;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Framework.Persistence;
using Spotfire.Dxp.Framework.Preferences;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Preference
{
    public enum Fonts
    {
        Arial,
        Tahoma,
        Courier
    }

    [PersistenceVersion(1, 0)]
    public class PDRenderPreference : CustomPreference
    {
        private readonly PreferenceProperty<string> _branchMonomerBackgroundColor;
        private readonly PreferenceProperty<string> _branchMonomerFontColor;
        private readonly PreferenceProperty<string> _colorCodingInformationLinkGuid;
        private readonly PreferenceProperty<string> _defaultBackgroundColor;
        private readonly PreferenceProperty<string> _defaultFontColor;
        private readonly PreferenceProperty<Fonts> _font;
        private readonly PreferenceProperty<int> _maxAminoAcids;

        public PDRenderPreference()
        {
            _maxAminoAcids = AddPreference(new PreferenceProperty<int>(
                "Max number of amino acids", 
                "1.0", 
                PreferencePersistenceScope.Server, 
                PreferenceUsage.UserGroup,
                PDRenderAddin.DefaultFontSize));

            _colorCodingInformationLinkGuid = AddPreference(new PreferenceProperty<string>(
                "Color coding Information Link GUID", 
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup));

            _defaultFontColor = AddPreference(new PreferenceProperty<string>(
                "Default font color (Hex)",
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup));

            _defaultBackgroundColor = AddPreference(new PreferenceProperty<string>(
                "Default background color (Hex)",
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup));

            _branchMonomerFontColor = AddPreference(new PreferenceProperty<string>(
                "Branch monomer font color (Hex)",
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup));

            _branchMonomerBackgroundColor = AddPreference(new PreferenceProperty<string>(
                "Branch monomer background color (Hex)",
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup));

            _font = AddPreference(new PreferenceProperty<Fonts>(
                "Font",
                "1.0",
                PreferencePersistenceScope.Server,
                PreferenceUsage.UserGroup,
                Fonts.Arial));
        }

        public override string Category => Resources.AddinName;

        public override string SubCategory => "Renderer Settings";

        public int MaxAminoAcids
        {
            get { return _maxAminoAcids.Value; }
            set { _maxAminoAcids.Value = value; }
        }

        public string ColorCodingInformationLinkGuid
        {
            get { return _colorCodingInformationLinkGuid.Value; }
            set { _colorCodingInformationLinkGuid.Value = value; }
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

        public Fonts Font
        {
            get { return _font.Value; }
            set { _font.Value = value; }
        }
    }
}
