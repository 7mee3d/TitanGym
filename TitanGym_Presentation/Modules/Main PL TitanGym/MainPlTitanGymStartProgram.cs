using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.UsersBL;
using TitanGym_Presentation.Core.Utility;
using TitanGym_Presentation.Modules.Dashboard.Forms;
using TitanGym_Presentation.Modules.Login.Forms;
using TitanGym_Presentation.Modules.Members.Forms;
using TitanGym_Presentation.Modules.Payments.Forms;
using TitanGym_Presentation.Modules.People.Forms;
using TitanGym_Presentation.Modules.Plans.Forms;
using TitanGym_Presentation.Modules.Subscriptions.Forms;
using TitanGym_Presentation.Modules.Trainer_Assignments.Forms;
using TitanGym_Presentation.Modules.Trainers.Forms;
using TitanGym_Presentation.Modules.Users.Forms;
using TitanGym_Presentation.Properties;

namespace TitanGym_Presentation
{
    public partial class MainPlTitanGymStartProgram : Form
    {
        private UserBL _InfomrationUser;

        public MainPlTitanGymStartProgram(UserBL infromtionUser)
        {
            InitializeComponent();
            _InfomrationUser = infromtionUser;


        }

        private void GGradientButtonPeople_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCPeopleList());
        }

        private void MainPlTitanGymStartProgram_Load(object sender, EventArgs e)
        {
            AppNavigator.Initialization(MainPanel);
            AppNavigator.Show(new UCDashboard());
            _LoadInformationUserAfterLogin();
        }

        private void _LoadInformationUserAfterLogin()
        {
            lblNameUser.Text = _InfomrationUser.InformationPerson.FirstName + " " + _InfomrationUser.InformationPerson.LastName;
            lblRole.Text = _InfomrationUser.InformationRole.RoleName;

            if (!string.IsNullOrWhiteSpace(_InfomrationUser.InformationPerson.ImagePath))
                GPictureBoxUser.ImageLocation = Utility.DirectoryPath + _InfomrationUser.InformationPerson.ImagePath;
            else
                GPictureBoxUser.Image = Resources.account_circle_Icon_TitanGym_50;
        }

        private void GGradientButtonMember_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCMemberList());
        }

        private void GGradientButtonTrainers_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCTrainersList());
        }

        private void GGradientButtonPlans_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCMembershipPlansList());
        }

        private void GGradientButtonPayments_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCPaymentsList());

        }

        private void GGradientButtonSubscriptions_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCSubscriptionsList());
        }

        private void GGButtonUsers_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCUsersList());
        }

        private void GGradientButtonTrainerAssigenments_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCTrainerAssignmentsList());
        }

        private void GGradientButtonDashboard_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCDashboard());
        }

        private void MainPlTitanGymStartProgram_Activated(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCDashboard());
        }

        private void GGButtonExitTitanGYM_Click(object sender, EventArgs e)
        {
            this.Close();

            UCLoginTitanGym uCLoginTitanGym = new UCLoginTitanGym();
            uCLoginTitanGym.ShowDialog();

        }
    }
}
