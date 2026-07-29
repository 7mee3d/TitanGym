namespace TitanGym_Presentation.Modules.Members.Forms
{
    partial class UCAddEditInformationMember
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddEditInformationMember));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GTextBoxEmergencyContactPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.GTextBoxEmergencyContactName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlShowInformationPersonByFilter1 = new TitanGym_Presentation.Modules.People.Controls.ctrlShowInformationPersonByFilter();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.GGButtonAddNewMember = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GGButtonCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitlePerson = new System.Windows.Forms.Label();
            this.ErrorProviderMemberSection = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMemberSection)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.GTextBoxEmergencyContactPhoneNumber);
            this.guna2Panel1.Controls.Add(this.GTextBoxEmergencyContactName);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.ctrlShowInformationPersonByFilter1);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Location = new System.Drawing.Point(242, 90);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(993, 681);
            this.guna2Panel1.TabIndex = 1;
            // 
            // GTextBoxEmergencyContactPhoneNumber
            // 
            this.GTextBoxEmergencyContactPhoneNumber.Animated = true;
            this.GTextBoxEmergencyContactPhoneNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.GTextBoxEmergencyContactPhoneNumber.BorderRadius = 4;
            this.GTextBoxEmergencyContactPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxEmergencyContactPhoneNumber.DefaultText = "";
            this.GTextBoxEmergencyContactPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxEmergencyContactPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxEmergencyContactPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxEmergencyContactPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxEmergencyContactPhoneNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.GTextBoxEmergencyContactPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxEmergencyContactPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxEmergencyContactPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.GTextBoxEmergencyContactPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GTextBoxEmergencyContactPhoneNumber.Location = new System.Drawing.Point(527, 505);
            this.GTextBoxEmergencyContactPhoneNumber.Name = "GTextBoxEmergencyContactPhoneNumber";
            this.GTextBoxEmergencyContactPhoneNumber.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.GTextBoxEmergencyContactPhoneNumber.PlaceholderText = "12312123";
            this.GTextBoxEmergencyContactPhoneNumber.SelectedText = "";
            this.GTextBoxEmergencyContactPhoneNumber.Size = new System.Drawing.Size(377, 46);
            this.GTextBoxEmergencyContactPhoneNumber.TabIndex = 4;
            this.GTextBoxEmergencyContactPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GTextBoxEmergencyContactPhoneNumber_KeyPress);
            this.GTextBoxEmergencyContactPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.GTextBoxValidating);
            // 
            // GTextBoxEmergencyContactName
            // 
            this.GTextBoxEmergencyContactName.Animated = true;
            this.GTextBoxEmergencyContactName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.GTextBoxEmergencyContactName.BorderRadius = 4;
            this.GTextBoxEmergencyContactName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxEmergencyContactName.DefaultText = "";
            this.GTextBoxEmergencyContactName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxEmergencyContactName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxEmergencyContactName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxEmergencyContactName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxEmergencyContactName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.GTextBoxEmergencyContactName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxEmergencyContactName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxEmergencyContactName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.GTextBoxEmergencyContactName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GTextBoxEmergencyContactName.Location = new System.Drawing.Point(63, 505);
            this.GTextBoxEmergencyContactName.Name = "GTextBoxEmergencyContactName";
            this.GTextBoxEmergencyContactName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(74)))));
            this.GTextBoxEmergencyContactName.PlaceholderText = "e.g Emad";
            this.GTextBoxEmergencyContactName.SelectedText = "";
            this.GTextBoxEmergencyContactName.Size = new System.Drawing.Size(377, 46);
            this.GTextBoxEmergencyContactName.TabIndex = 5;
            this.GTextBoxEmergencyContactName.Validating += new System.ComponentModel.CancelEventHandler(this.GTextBoxValidating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IBM Plex Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(523, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Emergency Contact Phone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IBM Plex Sans SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(56, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Emergency Contact Name";
            // 
            // ctrlShowInformationPersonByFilter1
            // 
            this.ctrlShowInformationPersonByFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.ctrlShowInformationPersonByFilter1.Location = new System.Drawing.Point(39, 121);
            this.ctrlShowInformationPersonByFilter1.Name = "ctrlShowInformationPersonByFilter1";
            this.ctrlShowInformationPersonByFilter1.Size = new System.Drawing.Size(915, 333);
            this.ctrlShowInformationPersonByFilter1.TabIndex = 1;
            this.ctrlShowInformationPersonByFilter1.EHFinishedSearchPerson += new System.EventHandler<int>(this.ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.guna2Panel3.BorderRadius = 8;
            this.guna2Panel3.Controls.Add(this.GGButtonAddNewMember);
            this.guna2Panel3.Controls.Add(this.GGButtonCancel);
            this.guna2Panel3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel3.Location = new System.Drawing.Point(2, 594);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(990, 87);
            this.guna2Panel3.TabIndex = 0;
            // 
            // GGButtonAddNewMember
            // 
            this.GGButtonAddNewMember.Animated = true;
            this.GGButtonAddNewMember.AnimatedGIF = true;
            this.GGButtonAddNewMember.BackColor = System.Drawing.Color.Transparent;
            this.GGButtonAddNewMember.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewMember.BorderRadius = 5;
            this.GGButtonAddNewMember.BorderThickness = 1;
            this.GGButtonAddNewMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGButtonAddNewMember.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewMember.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewMember.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewMember.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewMember.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonAddNewMember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewMember.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewMember.Font = new System.Drawing.Font("IBM Plex Sans Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonAddNewMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(110)))));
            this.GGButtonAddNewMember.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewMember.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewMember.Image = ((System.Drawing.Image)(resources.GetObject("GGButtonAddNewMember.Image")));
            this.GGButtonAddNewMember.ImageOffset = new System.Drawing.Point(-5, 0);
            this.GGButtonAddNewMember.Location = new System.Drawing.Point(774, 22);
            this.GGButtonAddNewMember.Name = "GGButtonAddNewMember";
            this.GGButtonAddNewMember.Size = new System.Drawing.Size(198, 47);
            this.GGButtonAddNewMember.TabIndex = 2;
            this.GGButtonAddNewMember.Text = "Add Member";
            this.GGButtonAddNewMember.Click += new System.EventHandler(this.GGButtonAddNewMember_Click);
            // 
            // GGButtonCancel
            // 
            this.GGButtonCancel.Animated = true;
            this.GGButtonCancel.AnimatedGIF = true;
            this.GGButtonCancel.BackColor = System.Drawing.Color.Transparent;
            this.GGButtonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonCancel.BorderRadius = 5;
            this.GGButtonCancel.BorderThickness = 1;
            this.GGButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGButtonCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonCancel.Font = new System.Drawing.Font("IBM Plex Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GGButtonCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonCancel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GGButtonCancel.Location = new System.Drawing.Point(637, 22);
            this.GGButtonCancel.Name = "GGButtonCancel";
            this.GGButtonCancel.Size = new System.Drawing.Size(129, 47);
            this.GGButtonCancel.TabIndex = 2;
            this.GGButtonCancel.Text = "Cancel";
            this.GGButtonCancel.Click += new System.EventHandler(this.GGButtonCancel_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderRadius = 8;
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.lblTitlePerson);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel2.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(987, 101);
            this.guna2Panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IBM Plex Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(201)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Register a new profile to the Apex Pulse ecosystem.";
            // 
            // lblTitlePerson
            // 
            this.lblTitlePerson.AutoSize = true;
            this.lblTitlePerson.Font = new System.Drawing.Font("IBM Plex Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.lblTitlePerson.Location = new System.Drawing.Point(12, 19);
            this.lblTitlePerson.Name = "lblTitlePerson";
            this.lblTitlePerson.Size = new System.Drawing.Size(287, 45);
            this.lblTitlePerson.TabIndex = 0;
            this.lblTitlePerson.Text = "Add New Member";
            // 
            // ErrorProviderMemberSection
            // 
            this.ErrorProviderMemberSection.ContainerControl = this;
            // 
            // UCAddEditInformationMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UCAddEditInformationMember";
            this.Size = new System.Drawing.Size(1477, 885);
            this.Load += new System.EventHandler(this.UCAddEditInformationMember_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMemberSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private People.Controls.ctrlShowInformationPersonByFilter ctrlShowInformationPersonByFilter1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonAddNewMember;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonCancel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitlePerson;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxEmergencyContactPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxEmergencyContactName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider ErrorProviderMemberSection;
    }
}
