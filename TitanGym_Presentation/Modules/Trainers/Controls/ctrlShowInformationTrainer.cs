using System.Windows.Forms;
using TitanGym_BusinessLayer.TrainersBL;

namespace TitanGym_Presentation.Modules.Trainers.Controls
{
    public partial class ctrlShowInformationTrainer : UserControl
    {
        public ctrlShowInformationTrainer()
        {
            InitializeComponent();
        }

        private TrainerBL _InformationTrainer;

        public void LoadInformationTrainer(int trainerID)
        {

            if (trainerID <= 0) return;

            _InformationTrainer = TrainerBL.FindTrainerBy(trainerID);

            if (_InformationTrainer is null)
            {
                MessageBox.Show("This trainer not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblHireDate.Text = _InformationTrainer.HireDate.ToString("dd/MM/yyyy");
            lblSpecialization.Text = _InformationTrainer.SpecializationInformation.SpecializationName;
            lblEmploymentStatus.Text = _InformationTrainer.InformationEmploymentStatuses.EmploymentStatusesName;
            lblSalary.Text = $"{_InformationTrainer.Salary:C}";
            lblTrainerID.Text = trainerID.ToString();

            ctrlShowInformationPerson1.LoadInformationPerson(_InformationTrainer.PersonID);
        }
    }
}
