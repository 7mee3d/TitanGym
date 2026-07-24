using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.TrainersBL;

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
            //TrainerID	PersonID	FullName	SpecializationName	NameEmploymentStatus	HireDate	Salary	MemberAssignmentsWithTrainer
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
    }
}
