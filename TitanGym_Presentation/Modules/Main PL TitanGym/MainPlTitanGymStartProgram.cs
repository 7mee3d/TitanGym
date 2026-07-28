using System;
using System.Windows.Forms;
using TitanGym_Presentation.Modules.Members.Forms;
using TitanGym_Presentation.Modules.Payments.Forms;
using TitanGym_Presentation.Modules.People.Forms;
using TitanGym_Presentation.Modules.Plans.Forms;
using TitanGym_Presentation.Modules.Subscriptions.Forms;
using TitanGym_Presentation.Modules.Trainer_Assignments.Forms;
using TitanGym_Presentation.Modules.Trainers.Forms;
using TitanGym_Presentation.Modules.Users.Forms;

namespace TitanGym_Presentation
{
    public partial class MainPlTitanGymStartProgram : Form
    {
        public MainPlTitanGymStartProgram()
        {
            InitializeComponent();
        }

        private void GGradientButtonPeople_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCPeopleList());
        }

        private void MainPlTitanGymStartProgram_Load(object sender, EventArgs e)
        {
            AppNavigator.Initialization(MainPanel);
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
    }
}
