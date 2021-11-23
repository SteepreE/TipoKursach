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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(12, 415);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 23);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Старт";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(93, 393);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(104, 45);
            this.SpeedBar.TabIndex = 1;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.StartStopButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Label label1;
    }
}

