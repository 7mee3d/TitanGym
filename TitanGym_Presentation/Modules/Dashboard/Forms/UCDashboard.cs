using System;
using System.Data;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;
using TitanGym_BusinessLayer.PaymentsBL;
using TitanGym_BusinessLayer.SubscriptionBL;
using TitanGym_BusinessLayer.Trainer_AssignmentsBL;
using TitanGym_BusinessLayer.TrainersBL;
using TitanGym_BusinessLayer.UsersBL;

namespace TitanGym_Presentation.Modules.Dashboard.Forms
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();
        }
        private void _LoadInformationDashbaord()
        {

            lblTotalTrainers.Text = TrainerBL.GetAllTrainers().Rows.Count.ToString();
            lblTotalMembers.Text = MemberBL.GetAllMembers().Rows.Count.ToString();
            lblTotalSubscriptions.Text = SubscriptionBL.GetAllSubscription().Rows.Count.ToString();
            lblTotalAssigementMemberWithTrainer.Text = TrainerAssignmentsBL.GetTotalMemberAssigementsTrainers().ToString();

            string statusName = "Active";
            DataView tempView = new DataView(UserBL.GetAllUsers());
            tempView.RowFilter = $"[AccountStatusName] = '{statusName}'";
            lblTotalActiveUsers.Text = tempView.Count.ToString();

            double TotalRevenue = 0.0d;

            DataTable DTPayments = PaymentsBL.GetAllPayments();

            for (int counter = 0; counter < DTPayments.Rows.Count; counter += 1)
            {
                DataRow DR = DTPayments.Rows[counter];

                TotalRevenue += Convert.ToDouble(DR["Amount"]);
            }

            lblTotalRevenue.Text = TotalRevenue.ToString("C");
        }

        private void _LoadInformationSubscriptionInDGV()
        {
            var dt = SubscriptionBL.GetAllSubscription();
            if (dt == null) { GDataGridViewSubscriptions.DataSource = null; return; }

            DataView DVSubscription = new DataView(dt);
            DVSubscription.Sort = "[SubscriptionID] DESC";

            GDataGridViewSubscriptions.DataSource = DVSubscription;

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
        }
        private void UCDashboard_Load(object sender, EventArgs e)
        {
            _LoadInformationDashbaord();
            _LoadInformationSubscriptionInDGV();
        }
    }
}
