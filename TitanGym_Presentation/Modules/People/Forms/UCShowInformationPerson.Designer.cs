namespace TitanGym_Presentation.Modules.People.Forms
{
    partial class UCShowInformationPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.GGButtonBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrlShowInformationPerson1 = new TitanGym_Presentation.Modules.People.Controls.ctrlShowInformationPerson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IBM Plex Sans", 38.24999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(41, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 71);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show Information Person";
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
            this.GGButtonBack.Location = new System.Drawing.Point(284, 603);
            this.GGButtonBack.Name = "GGButtonBack";
            this.GGButtonBack.Size = new System.Drawing.Size(129, 47);
            this.GGButtonBack.TabIndex = 3;
            this.GGButtonBack.Text = "Back";
            this.GGButtonBack.Click += new System.EventHandler(this.GGButtonBack_Click);
            // 
            // ctrlShowInformationPerson1
            // 
            this.ctrlShowInformationPerson1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.ctrlShowInformationPerson1.Location = new System.Drawing.Point(284, 335);
            this.ctrlShowInformationPerson1.Name = "ctrlShowInformationPerson1";
            this.ctrlShowInformationPerson1.Size = new System.Drawing.Size(908, 237);
            this.ctrlShowInformationPerson1.TabIndex = 2;
            this.ctrlShowInformationPerson1.Load += new System.EventHandler(this.ctrlShowInformationPerson1_Load);
            // 
            // UCShowInformationPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.GGButtonBack);
            this.Controls.Add(this.ctrlShowInformationPerson1);
            this.Controls.Add(this.label1);
            this.Name = "UCShowInformationPerson";
            this.Size = new System.Drawing.Size(1477, 885);
            this.Load += new System.EventHandler(this.UCShowInformationPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.ctrlShowInformationPerson ctrlShowInformationPerson1;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonBack;
    }
}
