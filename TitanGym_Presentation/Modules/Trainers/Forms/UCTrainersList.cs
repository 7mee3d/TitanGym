using System;
using System.Data;
using System.Windows.Forms;
using TitanGym_BusinessLayer.TrainersBL;
using TitanGym_Presentation.Core.Helpers;
using TitanGym_Presentation.Modules.People.Forms;

namespace TitanGym_Presentation.Modules.Trainers.Forms
{
    public partial class UCTrainersList : UserControl
    {
        private DataTable _DT_AllInfoTrainers;

        public UCTrainersList()
        {
            InitializeComponent();
        }

        private void _LoadInformationTrainersInDGV()
        {
            _DT_AllInfoTrainers = TrainerBL.GetAllTrainers();
            GDataGridViewTrainers.DataSource = _DT_AllInfoTrainers;

            if (GDataGridViewTrainers.Rows.Count > 0)
            {
                GDataGridViewTrainers.Columns[0].HeaderText = "TRAINER ID";
                GDataGridViewTrainers.Columns[0].Width = 100;

                GDataGridViewTrainers.Columns[1].HeaderText = "PERSON ID";
                GDataGridViewTrainers.Columns[1].Width = 100;

                GDataGridViewTrainers.Columns[2].HeaderText = "FULL NAME";
                GDataGridViewTrainers.Columns[2].Width = 150;

                GDataGridViewTrainers.Columns[3].HeaderText = "SPECIALIZATION";
                GDataGridViewTrainers.Columns[3].Width = 150;

                GDataGridViewTrainers.Columns[4].HeaderText = "EMPLOYMENT STATUS";
                GDataGridViewTrainers.Columns[4].Width = 110;

                GDataGridViewTrainers.Columns[5].HeaderText = "HIRE DATE";
                GDataGridViewTrainers.Columns[5].Width = 70;

                GDataGridViewTrainers.Columns[6].HeaderText = "SALARY";
                GDataGridViewTrainers.Columns[6].Width = 70;

                GDataGridViewTrainers.Columns[7].HeaderText = "TOTAL MEMBERS";
                GDataGridViewTrainers.Columns[7].Width = 70;
            }

        }

        private void UCTrainersList_Load(object sender, EventArgs e)
        {
            _LoadInformationTrainersInDGV();
        }

        private void GGButtonAddNewTrainer_Click(object sender, EventArgs e)
        {
            var ucAddEditInfoTrainer = new UCAddEditTrainer();

            ucAddEditInfoTrainer.FinishedAddEditInfoTrainer += result =>
            {
                if (result) UCTrainersList_Load(null, null);
            };

            AppNavigator.Show(ucAddEditInfoTrainer);
        }

        private void updateInformationTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainers, 0);

            var ucAddEditInfoTrainer = new UCAddEditTrainer(TrainerID);

            ucAddEditInfoTrainer.FinishedAddEditInfoTrainer += result =>
            {
                if (result) UCTrainersList_Load(null, null);
            };

            AppNavigator.Show(ucAddEditInfoTrainer);
        }

        private void addNewTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ucAddEditInfoTrainer = new UCAddEditTrainer();

            ucAddEditInfoTrainer.FinishedAddEditInfoTrainer += result =>
            {
                if (result) UCTrainersList_Load(null, null);
            };

            AppNavigator.Show(ucAddEditInfoTrainer);
        }

        private void ShowInformationPersontoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainers, 1);

            var ucShowInformationPerson = new UCShowInformationPerson(PersonID);

            ucShowInformationPerson.FinishedShowInfoPerson += result =>
            {
                if (result) UCTrainersList_Load(null, null);
            };


            AppNavigator.Show(ucShowInformationPerson);
        }

        private void deleteTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(
                "Are you sure to be delete this trainer ?",
                "Message",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation) == DialogResult.Cancel
                )

                return;

            int TrainerID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainers, 0);


            if (TrainerBL.DeleteTrainer(TrainerID))
            {
                UCTrainersList_Load(null, null);
                MessageBox.Show("The trainer deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("The trainer deleted Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void showInformationTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewTrainers, 0);

            var ucShowInformationTrainer = new UCShowInformationTrainer(TrainerID);

            ucShowInformationTrainer.FinishedShowInfoTrainer += result =>
            {
                if (result) UCTrainersList_Load(null, null);
            };

            AppNavigator.Show(ucShowInformationTrainer);
        }
    }
}
