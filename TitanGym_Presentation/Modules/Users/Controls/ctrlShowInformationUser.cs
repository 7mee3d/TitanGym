using System.Windows.Forms;
using TitanGym_BusinessLayer.UsersBL;

namespace TitanGym_Presentation.Modules.Users.Controls
{
    public partial class ctrlShowInformationUser : UserControl
    {
        public ctrlShowInformationUser()
        {
            InitializeComponent();
        }

        private UserBL _InformationUser;

        private void _DefaultValues()
        {

            lblAccountStatus.Text = "[???]";
            lblCreationDateUser.Text = "[???]";
            lblRoleName.Text = "[???]";
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";

            ctrlShowInformationPerson1._DefaultValues();
        }

        public void LoadInformationUser(int userID)
        {

            if (userID <= 0) return;

            _InformationUser = UserBL.FindTheUserBy(userID);

            if (_InformationUser is null)
            {
                _DefaultValues();
                MessageBox.Show("This user is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAccountStatus.Text = _InformationUser.InformationAccountStatus.AccountStatusName;
            lblCreationDateUser.Text = _InformationUser.CreationDateUser.ToString("dd/MM/yyyy");
            lblRoleName.Text = _InformationUser.InformationRole.RoleName;
            lblUserID.Text = _InformationUser.UserID.ToString();
            lblUsername.Text = _InformationUser.Username;

            ctrlShowInformationPerson1.LoadInformationPerson(_InformationUser.PersonID);

        }
    }
}
