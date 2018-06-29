// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDRendererSettingsDialog.cs" company="PerkinElmer Inc.">
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
using System.Windows.Forms;
using Com.PerkinElmer.Service.PeptideSequenceRenderer.Models;

#endregion

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Views
{
    public partial class PDRendererSettingsDialog : Form
    {
        private readonly PDRenderSettings _model;

        public PDRendererSettingsDialog(PDRenderSettings model)
        {
            InitializeComponent();

            this._model = model;
        }

        public PDRendererSettingsDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _model.FontSize = fontSizeTrackBar.Value;
            _model.MaxAcidAmount = maxAcidNumberTrackBar.Value;
        }

        private void PDRendererSettingsDialog_Load(object sender, EventArgs e)
        {
            this.fontSizeTrackBar.Value = this._model.FontSize;
            this.maxAcidNumberTrackBar.Value = this._model.MaxAcidAmount;

            this.fontSizeValueLabel.Text = this._model.FontSize.ToString();
            this.acidNumberValueLabel.Text = this._model.MaxAcidAmount.ToString();
        }

        private void maxAcidNumberTrackBar_Scroll(object sender, EventArgs e)
        {
            this.fontSizeValueLabel.Text = this._model.FontSize.ToString();
            this.acidNumberValueLabel.Text = this._model.MaxAcidAmount.ToString();

            _model.FontSize = fontSizeTrackBar.Value;
            _model.MaxAcidAmount = maxAcidNumberTrackBar.Value;
        }

        private void fontSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.fontSizeValueLabel.Text = this._model.FontSize.ToString();
            this.acidNumberValueLabel.Text = this._model.MaxAcidAmount.ToString();

            _model.FontSize = fontSizeTrackBar.Value;
            _model.MaxAcidAmount = maxAcidNumberTrackBar.Value;
        }
    }
}
