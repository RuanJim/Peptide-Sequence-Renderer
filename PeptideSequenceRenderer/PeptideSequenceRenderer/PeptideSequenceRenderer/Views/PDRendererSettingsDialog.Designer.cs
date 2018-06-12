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
            this.acidNumberTextBox = new System.Windows.Forms.TextBox();
            this.fontSizeTextBox = new System.Windows.Forms.TextBox();
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
            this.fontSizeLabel.Location = new System.Drawing.Point(16, 71);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.fontSizeLabel.TabIndex = 1;
            this.fontSizeLabel.Text = "Font size";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(200, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(281, 103);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acidNumberTextBox
            // 
            this.acidNumberTextBox.Location = new System.Drawing.Point(158, 28);
            this.acidNumberTextBox.Name = "acidNumberTextBox";
            this.acidNumberTextBox.Size = new System.Drawing.Size(198, 20);
            this.acidNumberTextBox.TabIndex = 4;
            // 
            // fontSizeTextBox
            // 
            this.fontSizeTextBox.Location = new System.Drawing.Point(158, 63);
            this.fontSizeTextBox.Name = "fontSizeTextBox";
            this.fontSizeTextBox.Size = new System.Drawing.Size(198, 20);
            this.fontSizeTextBox.TabIndex = 5;
            // 
            // PDRendererSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 139);
            this.Controls.Add(this.fontSizeTextBox);
            this.Controls.Add(this.acidNumberTextBox);
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
            this.Text = Resources.AddinName;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label acidNumberLabel;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox acidNumberTextBox;
        private System.Windows.Forms.TextBox fontSizeTextBox;
    }
}