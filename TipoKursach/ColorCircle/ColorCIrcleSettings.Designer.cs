namespace TipoKursach
{
    partial class ColorCIrcleSettings
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SetColorButton = new System.Windows.Forms.Button();
            this.ColorBox = new System.Windows.Forms.PictureBox();
            this.RadiusSelector = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // SetColorButton
            // 
            this.SetColorButton.Location = new System.Drawing.Point(12, 12);
            this.SetColorButton.Name = "SetColorButton";
            this.SetColorButton.Size = new System.Drawing.Size(123, 50);
            this.SetColorButton.TabIndex = 0;
            this.SetColorButton.Text = "Set color";
            this.SetColorButton.UseVisualStyleBackColor = true;
            this.SetColorButton.Click += new System.EventHandler(this.SetColorButton_Click);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(141, 12);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(75, 50);
            this.ColorBox.TabIndex = 2;
            this.ColorBox.TabStop = false;
            // 
            // RadiusSelector
            // 
            this.RadiusSelector.Location = new System.Drawing.Point(12, 78);
            this.RadiusSelector.Maximum = 100;
            this.RadiusSelector.Minimum = 25;
            this.RadiusSelector.Name = "RadiusSelector";
            this.RadiusSelector.Size = new System.Drawing.Size(204, 45);
            this.RadiusSelector.TabIndex = 3;
            this.RadiusSelector.Value = 25;
            this.RadiusSelector.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // ColorCIrcleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 127);
            this.Controls.Add(this.RadiusSelector);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.SetColorButton);
            this.Name = "ColorCIrcleSettings";
            this.Text = "ColorCIrcleSettings";
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button SetColorButton;
        private System.Windows.Forms.PictureBox ColorBox;
        private System.Windows.Forms.TrackBar RadiusSelector;
    }
}