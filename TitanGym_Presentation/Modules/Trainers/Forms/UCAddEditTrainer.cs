using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.Employment_StatusesBL;
using TitanGym_BusinessLayer.Specialization;
using TitanGym_BusinessLayer.TrainersBL;

namespace TitanGym_Presentation.Modules.Trainers.Forms
{
    public partial class UCAddEditTrainer : UserControl
    {
        private int _PersonID = -1;
        private int _TrainerID = -1;
        private _EnTrainerMode _ModeTrainer;
        private TrainerBL _InformationTrainer;
        public event Action<bool> FinishedAddEditInfoTrainer;

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

        public UCAddEditTrainer(int trainerID)
        {
            InitializeComponent();
            _ModeTrainer = _EnTrainerMode._kUPDATE_INFORMATION_TRAINER;
            _TrainerID = trainerID;
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

            _InformationTrainer = TrainerBL.FindTrainerBy(_TrainerID);

            if (_InformationTrainer is null)
            {
                MessageBox.Show("This trainer is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ModeTrainer = _EnTrainerMode._kUPDATE_INFORMATION_TRAINER;
            lblTitleTrainer.Text = "Update Trainer";
            GGButtonAddNewTrainer.Text = "Update Trainer";
        }

        private void _LoadInformationTrainer()
        {
            ctrlShowInformationPersonByFilter1.EnableControls = false;
            ctrlShowInformationPersonByFilter1.LoadInformationPerson(_InformationTrainer.PersonID);
            GTextBoxSalary.Text = _InformationTrainer.Salary.ToString();
            GComboBoxSpecialization.SelectedValue = _InformationTrainer.SpecializationID;
            GComboBoxEmploymentStatus.SelectedValue = _InformationTrainer.EmploymentStatusID;
        }

        private void _PrepareInformationTrainer()
        {
            _InformationTrainer.EmploymentStatusID =
                SpecializationBL.FindTheSpecializationBy(GComboBoxSpecialization.Text).SpecializationID;
            _InformationTrainer.SpecializationID =
                EmploymentStatusesBL.FindEmploymentStatuesBy(GComboBoxEmploymentStatus.Text).EmploymentStatusesID;
            _InformationTrainer.Salary = Convert.ToDouble(GTextBoxSalary.Text.Trim());

            if (_ModeTrainer == _EnTrainerMode._kADD_NEW_TRAINER)
                _InformationTrainer.HireDate = DateTime.Now;

            _InformationTrainer.PersonID = _PersonID;

        }

        private bool _PrepareContraintTrainerSextion()
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                  "Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                  "Validation Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );
                return false;
            }


            if (_PersonID == -1)
            {
                MessageBox.Show(
                "Please , Must select the person to be link the person with trainer",
                "Message Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }

            if (_ModeTrainer == _EnTrainerMode._kADD_NEW_TRAINER)
                if (TrainerBL.IsExistsTrainerBy(_PersonID))
                {
                    MessageBox.Show(
                    "This person already linking with other trainer , try enter again",
                    "Message Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                    return false;
                }

            return true;
        }

        private void _AddNewTrainer()
        {
            if (!_PrepareContraintTrainerSextion()) return;

            _PrepareInformationTrainer();

            if (_InformationTrainer.SaveModeTrainer())
            {
                FinishedAddEditInfoTrainer?.Invoke(true);

                if (_ModeTrainer == _EnTrainerMode._kADD_NEW_TRAINER)
                    MessageBox.Show("The trainer added sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The trainer updated  sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("The trainer added/Updated faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lblTitleTrainer.Text = "Update Trainer";
            GGButtonAddNewTrainer.Text = "Update Trainer";
            _ModeTrainer = _EnTrainerMode._kUPDATE_INFORMATION_TRAINER;
        }

        private void UCAddEditTrainer_Load(object sender, EventArgs e)
        {
            _DefaulValuesTrainersSection();

            if (_ModeTrainer == _EnTrainerMode._kUPDATE_INFORMATION_TRAINER)
                _LoadInformationTrainer();
        }

        private void ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson(object sender, int e)
        {
            int PersonID = e;

            if (PersonID == -1) return;

            _PersonID = PersonID;
        }

        private void GGButtonAddNewTrainer_Click(object sender, EventArgs e)
        {
            _AddNewTrainer();
        }

        private void GTextBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.');
        }
    }
}
