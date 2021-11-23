namespace TipoKursach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartStopButton = new System.Windows.Forms.Button();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.DirectionSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(12, 8);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 23);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(93, 8);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.RightToLeftLayout = true;
            this.SpeedBar.Size = new System.Drawing.Size(104, 45);
            this.SpeedBar.TabIndex = 1;
            this.SpeedBar.Value = 10;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(12, 30);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(75, 23);
            this.NextStepButton.TabIndex = 3;
            this.NextStepButton.Text = "Next Step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 374);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(128, 40);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "Speed";
            // 
            // DirectionSelector
            // 
            this.DirectionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectionSelector.FormattingEnabled = true;
            this.DirectionSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DirectionSelector.Location = new System.Drawing.Point(203, 8);
            this.DirectionSelector.Name = "DirectionSelector";
            this.DirectionSelector.Size = new System.Drawing.Size(121, 21);
            this.DirectionSelector.TabIndex = 6;
            this.DirectionSelector.SelectionChangeCommitted += new System.EventHandler(this.DirectionSelector_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Direction";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.InfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoLabel.Location = new System.Drawing.Point(753, 8);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 16);
            this.InfoLabel.TabIndex = 8;
            this.InfoLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 442);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DirectionSelector);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.StartStopButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.ComboBox DirectionSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InfoLabel;
    }
}

