namespace TitanGym_Presentation.Modules.Trainers.Forms
{
    partial class UCShowInformationTrainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GGButtonBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowInformationTrainer1 = new TitanGym_Presentation.Modules.Trainers.Controls.ctrlShowInformationTrainer();
            this.SuspendLayout();
            // 
            // GGButtonBack
            // 
            this.GGButtonBack.Animated = true;
            this.GGButtonBack.AnimatedGIF = true;
            this.GGButtonBack.BackColor = System.Drawing.Color.Transparent;
            this.GGButtonBack.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonBack.BorderRadius = 5;
            this.GGButtonBack.BorderThickness = 1;
            this.GGButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGButtonBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonBack.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonBack.Font = new System.Drawing.Font("IBM Plex Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonBack.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonBack.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonBack.Location = new System.Drawing.Point(229, 627);
            this.GGButtonBack.Name = "GGButtonBack";
            this.GGButtonBack.Size = new System.Drawing.Size(129, 47);
            this.GGButtonBack.TabIndex = 6;
            this.GGButtonBack.Text = "Back";
            this.GGButtonBack.Click += new System.EventHandler(this.GGButtonBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IBM Plex Sans", 38.24999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(41, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 71);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show Information Person";
            // 
            // ctrlShowInformationTrainer1
            // 
            this.ctrlShowInformationTrainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.ctrlShowInformationTrainer1.Location = new System.Drawing.Point(229, 327);
            this.ctrlShowInformationTrainer1.Name = "ctrlShowInformationTrainer1";
            this.ctrlShowInformationTrainer1.Size = new System.Drawing.Size(1018, 260);
            this.ctrlShowInformationTrainer1.TabIndex = 7;
            // 
            // UCShowInformationTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.ctrlShowInformationTrainer1);
            this.Controls.Add(this.GGButtonBack);
            this.Controls.Add(this.label1);
            this.Name = "UCShowInformationTrainer";
            this.Size = new System.Drawing.Size(1477, 956);
            this.Load += new System.EventHandler(this.UCShowInformationTrainer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton GGButtonBack;
        private System.Windows.Forms.Label label1;
        private Controls.ctrlShowInformationTrainer ctrlShowInformationTrainer1;
    }
}
