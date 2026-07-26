using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.SubscriptionBL;
using TitanGym_Presentation.Core.Helpers;

namespace TitanGym_Presentation.Modules.Subscriptions.Forms
{
    public partial class UCSubscriptionsList : UserControl
    {
        public UCSubscriptionsList()
        {
            InitializeComponent();
        }
        private DataTable _DT_AllSubscriptions;

        private void _LoadInformationSubscriptions()
        {
            _DT_AllSubscriptions = SubscriptionBL.GetAllSubscription();
            GDataGridViewSubscriptions.DataSource = _DT_AllSubscriptions;

            if (GDataGridViewSubscriptions.Rows.Count > 0)
            {
                GDataGridViewSubscriptions.Columns[0].HeaderText = "SUBSCRIPTION ID";
                GDataGridViewSubscriptions.Columns[0].Width = 65;

                GDataGridViewSubscriptions.Columns[1].HeaderText = "MEMBER ID";
                GDataGridViewSubscriptions.Columns[1].Width = 65;

                GDataGridViewSubscriptions.Columns[2].HeaderText = "MEMBERSHIP ID";
                GDataGridViewSubscriptions.Columns[2].Width = 65;

                GDataGridViewSubscriptions.Columns[3].HeaderText = "MEMBER NAME";
                GDataGridViewSubscriptions.Columns[3].Width = 200;

                GDataGridViewSubscriptions.Columns[4].HeaderText = "MEMBERSHIP NAME";
                GDataGridViewSubscriptions.Columns[4].Width = 100;

                GDataGridViewSubscriptions.Columns[5].HeaderText = "DURATION";
                GDataGridViewSubscriptions.Columns[5].Width = 50;

                GDataGridViewSubscriptions.Columns[6].HeaderText = "START DATE";
                GDataGridViewSubscriptions.Columns[6].Width = 90;

                GDataGridViewSubscriptions.Columns[7].HeaderText = "END DATE";
                GDataGridViewSubscriptions.Columns[7].Width = 90;

                GDataGridViewSubscriptions.Columns[8].HeaderText = "SUBSCRIPTION FEES";
                GDataGridViewSubscriptions.Columns[8].Width = 75;

                GDataGridViewSubscriptions.Columns[9].HeaderText = "SUBSCRIPTION STATUS";
                GDataGridViewSubscriptions.Columns[9].Width = 85;
            }

            lblTotalSubscriptions.Text = GDataGridViewSubscriptions.Rows.Count.ToString();

            int TotalActiveSubscriptions = 0;

            foreach (DataRow DR in _DT_AllSubscriptions.Rows)
                if (DR["NameSubscriptionStatus"].ToString() == "Active")
                    ++TotalActiveSubscriptions;

            lblTotalActiveSubscriptions.Text = TotalActiveSubscriptions.ToString();
        }

        private void UCSubscriptionsList_Load(object sender, EventArgs e)
        {
            _LoadInformationSubscriptions();
        }

        private void GDataGridViewSubscriptions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void GGButtonAddNewSubscription_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCAddEditSubscription());
        }

        private void addNewSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ucAddEditSubscription = new UCAddEditSubscription();

            ucAddEditSubscription.FinishedAddEditSubscription += result =>
            {
                if (result) UCSubscriptionsList_Load(null, null);

            };

            AppNavigator.Show(ucAddEditSubscription);

        }

        private void updateInformationSubscritpionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SubscriptionID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewSubscriptions, 0);

            var ucAddEditSubscription = new UCAddEditSubscription(SubscriptionID);

            ucAddEditSubscription.FinishedAddEditSubscription += result =>
            {
                if (result) UCSubscriptionsList_Load(null, null);

            };

            AppNavigator.Show(ucAddEditSubscription);
        }

        private void expiredSubscriptiontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to be expire this subscription", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel) return;

            int SubscriptionID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewSubscriptions, 0);
            SubscriptionBL InfoSubscription = SubscriptionBL.FindTheSubscriptionBy(SubscriptionID);

            if (InfoSubscription.ExpireSubscription())
            {
                MessageBox.Show("The subscription expired sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UCSubscriptionsList_Load(null, null);
            }
            else MessageBox.Show("The subscription expired Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
