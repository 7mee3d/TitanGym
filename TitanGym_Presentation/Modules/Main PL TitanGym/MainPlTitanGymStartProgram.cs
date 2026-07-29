using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.UsersBL;
using TitanGym_Presentation.Core.Utility;
using TitanGym_Presentation.Modules.Dashboard.Forms;
using TitanGym_Presentation.Modules.Login.Forms;
using TitanGym_Presentation.Modules.Main_PL_TitanGym;
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

        private enum _EnPremissionsRole
        {
            _kDASHBOARD = 1,
            _kPEOPLE = 2,
            _kMEMBERS = 3,
            _kTRAINERS = 8,
            _kPLANS = 16,
            _kSUBSCRIPTIONS = 32,
            _kPAYMENT = 64,
            _kTRAINER_ASSIGEMENTS = 128,
            _kUSERS = 256
        };

        private bool _CheckTheUserPassPermissions(int Permissions, _EnPremissionsRole premissionsRole)
        {
            return ((Permissions & (int)premissionsRole) == (int)premissionsRole);
        }


        public MainPlTitanGymStartProgram(UserBL infromtionUser)
        {
            InitializeComponent();
            _InfomrationUser = infromtionUser;
        }

        private void _CheckAndShowUCAccordingPermissions(int Permissions, _EnPremissionsRole enPremissionsRole, UserControl userControl)
        {
            if (_CheckTheUserPassPermissions(Permissions, enPremissionsRole))
                AppNavigator.Show(userControl);
            else AppNavigator.Show(new UCScreenAccessDenied());
        }

        private void GGradientButtonPeople_Click(object sender, EventArgs e)
          => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kPEOPLE, new UCPeopleList());


        private void MainPlTitanGymStartProgram_Load(object sender, EventArgs e)
        {
            AppNavigator.Initialization(MainPanel);
            _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kDASHBOARD, new UCPeopleList());
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
            => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kMEMBERS, new UCMemberList());


        private void GGradientButtonTrainers_Click(object sender, EventArgs e)
         => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kTRAINERS, new UCTrainersList());


        private void GGradientButtonPlans_Click(object sender, EventArgs e)
          => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kPLANS, new UCMembershipPlansList());

        private void GGradientButtonPayments_Click(object sender, EventArgs e)
           => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kPAYMENT, new UCPaymentsList());


        private void GGradientButtonSubscriptions_Click(object sender, EventArgs e)
           => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kSUBSCRIPTIONS, new UCSubscriptionsList());


        private void GGButtonUsers_Click(object sender, EventArgs e)
          => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kUSERS, new UCUsersList());


        private void GGradientButtonTrainerAssigenments_Click(object sender, EventArgs e)
          => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kTRAINER_ASSIGEMENTS, new UCTrainerAssignmentsList());


        private void GGradientButtonDashboard_Click(object sender, EventArgs e)
           => _CheckAndShowUCAccordingPermissions(_InfomrationUser.InformationRole.PermissionsRole, _EnPremissionsRole._kDASHBOARD, new UCDashboard());


        private void GGButtonExitTitanGYM_Click(object sender, EventArgs e)
        {
            this.Close();

            UCLoginTitanGym uCLoginTitanGym = new UCLoginTitanGym();
            uCLoginTitanGym.ShowDialog();

        }
    }
}
