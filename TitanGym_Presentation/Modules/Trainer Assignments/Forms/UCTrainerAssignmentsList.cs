using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.SubscriptionBL;
using TitanGym_BusinessLayer.Trainer_AssignmentsBL;
using TitanGym_Presentation.Core.Helpers;
using TitanGym_Presentation.Modules.Subscriptions.Forms;

namespace TitanGym_Presentation.Modules.Trainer_Assignments.Forms
{
    public partial class UCTrainerAssignmentsList : UserControl
    {
        public UCTrainerAssignmentsList()
        {
            InitializeComponent();
        }
        private DataTable _DT_AllTrainerAssignemnts;

        private void _LoadInformationTrainerAssignments()
        {
            //TrainerAssignmentID	MemberID	TrainerName	MemberName	MembershipName	StartDate	EndDate	Note
            _DT_AllTrainerAssignemnts = TrainerAssignmentsBL.GetAllTrainerAssignments();
            GDataGridViewTrainerAssignments.DataSource = _DT_AllTrainerAssignemnts;

            if (GDataGridViewTrainerAssignments.Rows.Count > 0)
            {

                GDataGridViewTrainerAssignments.Columns[0].HeaderText = "TRAINER ASSIGENMENT ID";
                GDataGridViewTrainerAssignments.Columns[0].Width = 180;

                GDataGridViewTrainerAssignments.Columns[1].HeaderText = "MEMBER ID";
                GDataGridViewTrainerAssignments.Columns[1].Width = 120;

                GDataGridViewTrainerAssignments.Columns[2].HeaderText = "Trainer Full Name";
                GDataGridViewTrainerAssignments.Columns[2].Width = 200;

                GDataGridViewTrainerAssignments.Columns[3].HeaderText = "Member Full Name";
                GDataGridViewTrainerAssignments.Columns[3].Width = 200;

                GDataGridViewTrainerAssignments.Columns[4].HeaderText = "MEMBERSIPT TYPE";
                GDataGridViewTrainerAssignments.Columns[4].Width = 150;

                GDataGridViewTrainerAssignments.Columns[5].HeaderText = "START DATE";
                GDataGridViewTrainerAssignments.Columns[5].Width = 120;

                GDataGridViewTrainerAssignments.Columns[6].HeaderText = "END DATE";
                GDataGridViewTrainerAssignments.Columns[6].Width = 120;

                GDataGridViewTrainerAssignments.Columns[7].HeaderText = "NOTE";
                GDataGridViewTrainerAssignments.Columns[7].Width = 300;

            }

        }


        private void UCTrainerAssignmentsList_Load(object sender, EventArgs e)
        {
            _LoadInformationTrainerAssignments();
        }

        private void GGButtonAssigementMember_Click(object sender, EventArgs e)
        {
            var ucAssigmentMembertoTrainer = new UCAssigementEditMemberTrainer();

            ucAssigmentMembertoTrainer.FinishedAddEditAssigemntTrainer += result =>
            {
                if (result) UCTrainerAssignmentsList_Load(null, null);


            };

            AppNavigator.Show(ucAssigmentMembertoTrainer);
        }

        private void AssigementMemberToTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ucAssigmentMembertoTrainer = new UCAssigementEditMemberTrainer();

            ucAssigmentMembertoTrainer.FinishedAddEditAssigemntTrainer += result =>
            {
                if (result) UCTrainerAssignmentsList_Load(null, null);


            };

            AppNavigator.Show(ucAssigmentMembertoTrainer);
        }

        private void updateInformationAssigementMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerAssigementID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainerAssignments, 0);

            var ucAssigmentMembertoTrainer = new UCAssigementEditMemberTrainer(TrainerAssigementID);

            ucAssigmentMembertoTrainer.FinishedAddEditAssigemntTrainer += result =>
            {
                if (result) UCTrainerAssignmentsList_Load(null, null);


            };

            AppNavigator.Show(ucAssigmentMembertoTrainer);
        }

        private void showInformationSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainerAssignments, 1);

            int SubscriptionID = SubscriptionBL.FindTheSubscriptionByMemberID(MemberID).SubscriptionID;

            var ucShowInformationSubscription = new UCShowInformationSubscription(SubscriptionID);

            ucShowInformationSubscription.FinishedShowInfoSubscription += result =>
            {
                if (result) UCTrainerAssignmentsList_Load(null, null);
            };

            AppNavigator.Show(ucShowInformationSubscription);
        }
    }
}
