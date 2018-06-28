using Com.PerkinElmer.Service.PeptideSequenceRenderer.Properties;

namespace Com.PerkinElmer.Service.PeptideSequenceRenderer.Views
{
    partial class PDRendererSettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.acidNumberLabel = new System.Windows.Forms.Label();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fontSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.maxAcidNumberTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAcidNumberTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // acidNumberLabel
            // 
            this.acidNumberLabel.AutoSize = true;
            this.acidNumberLabel.Location = new System.Drawing.Point(16, 28);
            this.acidNumberLabel.Name = "acidNumberLabel";
            this.acidNumberLabel.Size = new System.Drawing.Size(136, 13);
            this.acidNumberLabel.TabIndex = 0;
            this.acidNumberLabel.Text = "Max number of amino acids";
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(16, 78);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(69, 13);
            this.fontSizeLabel.TabIndex = 1;
            this.fontSizeLabel.Text = "Font size (%):";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(210, 129);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(291, 129);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // fontSizeTrackBar
            // 
            this.fontSizeTrackBar.Location = new System.Drawing.Point(158, 75);
            this.fontSizeTrackBar.Maximum = 100;
            this.fontSizeTrackBar.Minimum = 20;
            this.fontSizeTrackBar.Name = "fontSizeTrackBar";
            this.fontSizeTrackBar.Size = new System.Drawing.Size(198, 45);
            this.fontSizeTrackBar.TabIndex = 6;
            this.fontSizeTrackBar.TickFrequency = 10;
            this.fontSizeTrackBar.Value = 20;
            // 
            // maxAcidNumberTrackBar
            // 
            this.maxAcidNumberTrackBar.Location = new System.Drawing.Point(158, 28);
            this.maxAcidNumberTrackBar.Maximum = 50;
            this.maxAcidNumberTrackBar.Minimum = 1;
            this.maxAcidNumberTrackBar.Name = "maxAcidNumberTrackBar";
            this.maxAcidNumberTrackBar.Size = new System.Drawing.Size(198, 45);
            this.maxAcidNumberTrackBar.TabIndex = 7;
            this.maxAcidNumberTrackBar.TickFrequency = 10;
            this.maxAcidNumberTrackBar.Value = 20;
            // 
            // PDRendererSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 167);
            this.Controls.Add(this.maxAcidNumberTrackBar);
            this.Controls.Add(this.fontSizeTrackBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.acidNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PDRendererSettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peptide Sequence Renderer";
            this.Load += new System.EventHandler(this.PDRendererSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAcidNumberTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label acidNumberLabel;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TrackBar fontSizeTrackBar;
        private System.Windows.Forms.TrackBar maxAcidNumberTrackBar;
    }
}