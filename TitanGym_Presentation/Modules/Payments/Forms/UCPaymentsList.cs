using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.PaymentsBL;
using TitanGym_Presentation.Core.Helpers;

namespace TitanGym_Presentation.Modules.Payments.Forms
{
    public partial class UCPaymentsList : UserControl
    {
        public UCPaymentsList()
        {
            InitializeComponent();
        }

        private DataTable _DT_AllInfomrationPayments;

        private void _LoadAllPayments()
        {
            //PaymentID	SubscriptionID	PaymentDate	Amount	Note	NamePaymentMethod	NamePaymentStatus 

            _DT_AllInfomrationPayments = PaymentsBL.GetAllPayments();
            GDataGridViewPayments.DataSource = _DT_AllInfomrationPayments;

            if (GDataGridViewPayments.Rows.Count > 0)
            {

                GDataGridViewPayments.Columns[0].HeaderText = "PAYMENT ID";
                GDataGridViewPayments.Columns[0].Width = 50;

                GDataGridViewPayments.Columns[1].HeaderText = "SUBSCRIPTION ID";
                GDataGridViewPayments.Columns[1].Width = 50;

                GDataGridViewPayments.Columns[2].HeaderText = "PAYMENT DATE";
                GDataGridViewPayments.Columns[2].Width = 80;

                GDataGridViewPayments.Columns[3].HeaderText = "AMOUNT";
                GDataGridViewPayments.Columns[3].Width = 65;

                GDataGridViewPayments.Columns[4].HeaderText = "NOTE";
                GDataGridViewPayments.Columns[4].Width = 65;

                GDataGridViewPayments.Columns[5].HeaderText = "PAYMENT METHOD";
                GDataGridViewPayments.Columns[5].Width = 80;

                GDataGridViewPayments.Columns[6].HeaderText = "PAYMENT STATUS";
                GDataGridViewPayments.Columns[6].Width = 80;

            }

        }
        private void UCPaymentsList_Load(object sender, EventArgs e)
        {
            _LoadAllPayments();
        }

        private void GDataGridViewPayments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double TotalRevenue = 0.0d;

            for (int counter = 0; counter < GDataGridViewPayments.Rows.Count; counter += 1)
            {
                DataGridViewRow DGVR = GDataGridViewPayments.Rows[counter];
                DataGridViewCell GDVC = DGVR.Cells[3];

                TotalRevenue += Convert.ToDouble(GDVC.Value);
            }



            lblTotalRevenue.Text = TotalRevenue.ToString("C");
        }

        private void showInformationPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewPayments, 0);

            var ucShowInforPayment = new UCShowInformationPayment(PaymentID);

            ucShowInforPayment.FinishedShowInfoPayment += result =>
            {
                if (result) UCPaymentsList_Load(null, null);

            };

            AppNavigator.Show(ucShowInforPayment);
        }

        private void GGButtonAddNewPayment_Click(object sender, EventArgs e)
        {

            var ucAddEditPayment = new UCAddEditPayments();

            ucAddEditPayment.FinishedAddEditPayment += result =>
            {
                if (result) UCPaymentsList_Load(null, null);

            };

            AppNavigator.Show(ucAddEditPayment);
        }
    }
}

