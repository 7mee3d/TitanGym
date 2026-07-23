using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.Employment_StatusesBL;
using TitanGym_BusinessLayer.Specialization;
using TitanGym_BusinessLayer.TrainersBL;

namespace TitanGym_Presentation.Modules.Trainers.Forms
{
    public partial class UCAddEditTrainer : UserControl
    {
        private int _PersonID = -1;
        private _EnTrainerMode _ModeTrainer;
        private TrainerBL _InformationTrainer;

        private enum _EnTrainerMode
        {
            _kADD_NEW_TRAINER = 1,
            _kUPDATE_INFORMATION_TRAINER = 2
        }

        public UCAddEditTrainer()
        {
            InitializeComponent();
            _ModeTrainer = _EnTrainerMode._kADD_NEW_TRAINER;
        }

        private void GGButtonCancel_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void _LoadAllInformationSpecializationsInCB()
        {
            GComboBoxSpecialization.DataSource = SpecializationBL.GetAllSpecializations();
            GComboBoxSpecialization.DisplayMember = "SpecializationName";
            GComboBoxSpecialization.ValueMember = "SpecializationID";
        }

        private void _LoadAllInformationEmploymentStatusesInCB()
        {

            GComboBoxEmploymentStatus.DataSource = EmploymentStatusesBL.GetAllEmploymentStatuses();
            GComboBoxEmploymentStatus.DisplayMember = "NameEmploymentStatus";
            GComboBoxEmploymentStatus.ValueMember = "EmploymentStatusID";
        }

        private void _DefaulValuesTrainersSection()
        {
            _LoadAllInformationSpecializationsInCB();
            _LoadAllInformationEmploymentStatusesInCB();

            if (_ModeTrainer == _EnTrainerMode._kADD_NEW_TRAINER)
            {

                _InformationTrainer = new TrainerBL();
                lblTitleTrainer.Text = "Add New Trainer";
                GGButtonAddNewTrainer.Text = "Add Trainer";
                return;
            }
        }
        private void UCAddEditTrainer_Load(object sender, EventArgs e)
        {
            _DefaulValuesTrainersSection();
        }

        private void ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson(object sender, int e)
        {
            int PersonID = e;

            if (PersonID == -1) return;

            _PersonID = PersonID;
        }
    }
}
