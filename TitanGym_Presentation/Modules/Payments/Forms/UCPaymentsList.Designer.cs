namespace TitanGym_Presentation.Modules.Payments.Forms
{
    partial class UCPaymentsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPaymentsList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GGButtonAddNewPayment = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.GDataGridViewPayments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ContextMenuStripPaymentsPlansSection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInformationPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewPayments)).BeginInit();
            this.ContextMenuStripPaymentsPlansSection.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GGButtonAddNewPayment
            // 
            this.GGButtonAddNewPayment.BorderRadius = 6;
            this.GGButtonAddNewPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGButtonAddNewPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewPayment.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonAddNewPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewPayment.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.GGButtonAddNewPayment.Font = new System.Drawing.Font("IBM Plex Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonAddNewPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.GGButtonAddNewPayment.Image = ((System.Drawing.Image)(resources.GetObject("GGButtonAddNewPayment.Image")));
            this.GGButtonAddNewPayment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GGButtonAddNewPayment.ImageOffset = new System.Drawing.Point(15, 1);
            this.GGButtonAddNewPayment.Location = new System.Drawing.Point(1226, 75);
            this.GGButtonAddNewPayment.Name = "GGButtonAddNewPayment";
            this.GGButtonAddNewPayment.Size = new System.Drawing.Size(203, 44);
            this.GGButtonAddNewPayment.TabIndex = 13;
            this.GGButtonAddNewPayment.Text = "NEW PAYMENT";
            this.GGButtonAddNewPayment.TextOffset = new System.Drawing.Point(10, 0);
            this.GGButtonAddNewPayment.Click += new System.EventHandler(this.GGButtonAddNewPayment_Click);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel2.BorderRadius = 5;
            this.guna2GradientPanel2.BorderThickness = 1;
            this.guna2GradientPanel2.Controls.Add(this.GDataGridViewPayments);
            this.guna2GradientPanel2.Location = new System.Drawing.Point(53, 315);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1379, 592);
            this.guna2GradientPanel2.TabIndex = 12;
            // 
            // GDataGridViewPayments
            // 
            this.GDataGridViewPayments.AllowUserToAddRows = false;
            this.GDataGridViewPayments.AllowUserToDeleteRows = false;
            this.GDataGridViewPayments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IBM Plex Sans Medium", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.GDataGridViewPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GDataGridViewPayments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GDataGridViewPayments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IBM Plex Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(201)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GDataGridViewPayments.ColumnHeadersHeight = 71;
            this.GDataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewPayments.ContextMenuStrip = this.ContextMenuStripPaymentsPlansSection;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("IBM Plex Sans Medium", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GDataGridViewPayments.DefaultCellStyle = dataGridViewCellStyle3;
            this.GDataGridViewPayments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.GDataGridViewPayments.Location = new System.Drawing.Point(3, 3);
            this.GDataGridViewPayments.MultiSelect = false;
            this.GDataGridViewPayments.Name = "GDataGridViewPayments";
            this.GDataGridViewPayments.ReadOnly = true;
            this.GDataGridViewPayments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GDataGridViewPayments.RowHeadersVisible = false;
            this.GDataGridViewPayments.RowTemplate.Height = 64;
            this.GDataGridViewPayments.Size = new System.Drawing.Size(1373, 586);
            this.GDataGridViewPayments.TabIndex = 0;
            this.GDataGridViewPayments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GDataGridViewPayments.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("IBM Plex Sans Medium", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewPayments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.GDataGridViewPayments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.GDataGridViewPayments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GDataGridViewPayments.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GDataGridViewPayments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.GDataGridViewPayments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.GDataGridViewPayments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("IBM Plex Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewPayments.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(201)))), ((int)(((byte)(204)))));
            this.GDataGridViewPayments.ThemeStyle.HeaderStyle.Height = 71;
            this.GDataGridViewPayments.ThemeStyle.ReadOnly = true;
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("IBM Plex Sans Medium", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.Height = 64;
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.GDataGridViewPayments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GDataGridViewPayments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GDataGridViewPayments_DataBindingComplete);
            // 
            // ContextMenuStripPaymentsPlansSection
            // 
            this.ContextMenuStripPaymentsPlansSection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInformationPaymentToolStripMenuItem});
            this.ContextMenuStripPaymentsPlansSection.Name = "ContextMenuStripPeopleSection";
            this.ContextMenuStripPaymentsPlansSection.Size = new System.Drawing.Size(255, 42);
            // 
            // showInformationPaymentToolStripMenuItem
            // 
            this.showInformationPaymentToolStripMenuItem.Font = new System.Drawing.Font("IBM Plex Sans Medium", 9.75F, System.Drawing.FontStyle.Bold);
            this.showInformationPaymentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showInformationPaymentToolStripMenuItem.Image")));
            this.showInformationPaymentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInformationPaymentToolStripMenuItem.Name = "showInformationPaymentToolStripMenuItem";
            this.showInformationPaymentToolStripMenuItem.Size = new System.Drawing.Size(254, 38);
            this.showInformationPaymentToolStripMenuItem.Text = "Show Information Payment";
            this.showInformationPaymentToolStripMenuItem.Click += new System.EventHandler(this.showInformationPaymentToolStripMenuItem_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.Controls.Add(this.lblTotalRevenue);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(56, 167);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(255, 115);
            this.guna2GradientPanel1.TabIndex = 11;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("IBM Plex Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(16, 52);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(39, 45);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IBM Plex Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(201)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Revenue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IBM Plex Sans", 38.24999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(44, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 71);
            this.label1.TabIndex = 8;
            this.label1.Text = "Payments Directory";
            // 
            // UCPaymentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.GGButtonAddNewPayment);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UCPaymentsList";
            this.Size = new System.Drawing.Size(1477, 956);
            this.Load += new System.EventHandler(this.UCPaymentsList_Load);
            this.guna2GradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewPayments)).EndInit();
            this.ContextMenuStripPaymentsPlansSection.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton GGButtonAddNewPayment;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2DataGridView GDataGridViewPayments;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripPaymentsPlansSection;
        private System.Windows.Forms.ToolStripMenuItem showInformationPaymentToolStripMenuItem;
    }
}
