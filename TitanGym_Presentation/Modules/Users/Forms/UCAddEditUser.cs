using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.Account_StatusesBL;
using TitanGym_BusinessLayer.RolesBL;
using TitanGym_BusinessLayer.UsersBL;

namespace TitanGym_Presentation.Modules.Users.Forms
{
    public partial class UCAddEditUser : UserControl
    {
        private enum _EnModeUsers
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2
        };
        private _EnModeUsers _ModeUser;
        private UserBL _InformationUser;
        private int _PersonID = -1;
        public event Action<bool> FinishedAddEditUser;


        public UCAddEditUser()
        {
            InitializeComponent();
            _ModeUser = _EnModeUsers._kADD_NEW_USER;
        }


        private void _LoadAllInformationRoleInCB()
        {
            GComboBoxRoles.DisplayMember = "RoleName";
            GComboBoxRoles.ValueMember = "RoleID";
            GComboBoxRoles.DataSource = RoleBL.GetAllRoles();
        }

        private void _LoadAllInformationAccountStatusesInCB()
        {

            GComboBoxAccountStatuses.DisplayMember = "AccountStatusName";
            GComboBoxAccountStatuses.ValueMember = "AccountStatusID";
            GComboBoxAccountStatuses.DataSource = AccountStatusBL.GetAllAccountStatuses();
        }

        private void _DefaultValues()
        {
            _LoadAllInformationRoleInCB();
            _LoadAllInformationAccountStatusesInCB();

            if (this._ModeUser == _EnModeUsers._kADD_NEW_USER)
            {
                _InformationUser = new UserBL();
                lblTitleUser.Text = "Add New User";
                GGButtonAddNewUser.Text = "Add User";
                return;
            }

        }

        private void _PrepareInformationUser()
        {

            _InformationUser.CreationDateUser = DateTime.Now;
            _InformationUser.Username = GTextBoxUsername.Text.Trim();
            _InformationUser.Password = GTextBoxPassword.Text.Trim();
            _InformationUser.PersonID = _PersonID;
            _InformationUser.RoleID = Convert.ToByte(GComboBoxRoles.SelectedValue);
            _InformationUser.AccountStatusID = Convert.ToByte(GComboBoxAccountStatuses.SelectedValue);
        }

        private void ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson(object sender, int e)
        {
            int PersonID = e;

            if (PersonID <= 0)
            {
                MessageBox.Show(
                    "Please,Select the valid person",
                    "Message Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            _PersonID = PersonID;
        }

        private bool _PrepareContraintsUsers()
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

            if (this._PersonID == -1)
            {
                MessageBox.Show(
                         "You must selected person according the filter",
                         "Message Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                  );

                return false;
            }

            if (this._ModeUser == _EnModeUsers._kADD_NEW_USER)
                if (UserBL.IsExistsUserBy(GTextBoxUsername.Text.Trim()))
                {
                    MessageBox.Show(
                          "This username already exists , try again",
                          "Message Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error
                   );

                    return false;
                }

            return true;
        }

        private void _AddNewUser()
        {

            if (!_PrepareContraintsUsers()) return;

            _PrepareInformationUser();

            if (_InformationUser.SaveModeUser())
            {
                FinishedAddEditUser?.Invoke(true);

                if (this._ModeUser == _EnModeUsers._kADD_NEW_USER)
                    MessageBox.Show(
                        "The user added sccessfully",
                        "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                else MessageBox.Show(
                    "The user updated sccessfully",
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                lblCreationDate.Text = _InformationUser.CreationDateUser.ToString("dd/MM/yyyy");
            }
            else MessageBox.Show(
                "The user added/Edited Faild",
                "Message Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );

            lblTitleUser.Text = "Update User";
            GGButtonAddNewUser.Text = "Update User";
            this._ModeUser = _EnModeUsers._kUPDATE_INFORMATION_USER;
        }

        private void UCAddEditUser_Load(object sender, EventArgs e)
        {
            _DefaultValues();
        }

        private void GGButtonAddNewUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void GTextBoxUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GTextBoxUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderUsersSection.SetError(GTextBoxUsername, "The Feild Is Empty");
            }
            else
                e.Cancel = false;


            if (this._ModeUser == _EnModeUsers._kADD_NEW_USER)
                if (UserBL.IsExistsUserBy(GTextBoxUsername.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProviderUsersSection.SetError(GTextBoxUsername, "This username already exists");
                }
                else
                    e.Cancel = false;

        }

        private void GTextBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GTextBoxPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderUsersSection.SetError(GTextBoxPassword, "The Feild Is Empty");
            }
            else
                e.Cancel = false;

        }
    }
}
