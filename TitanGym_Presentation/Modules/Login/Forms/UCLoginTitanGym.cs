using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TitanGym_BusinessLayer.UsersBL;
using TitanGym_Presentation.Core.Globals;
using TitanGym_Presentation.Core.Utility;

namespace TitanGym_Presentation.Modules.Login.Forms
{
    public partial class UCLoginTitanGym : Form
    {
        public UCLoginTitanGym()
        {
            InitializeComponent();
        }

        private void LunchTitanGymAfterLogin(int UserID)
        {
            this.Hide();

            var UserInformation = UserBL.FindTheUserBy(UserID);
            Global.InformationLoginedUser = UserInformation;

            MainPlTitanGymStartProgram TitanGym = new MainPlTitanGymStartProgram(Global.InformationLoginedUser);
            TitanGym.ShowDialog();
        }

        private void LoginTitanGym()
        {
            string Username = GTextBoxUsername.Text.Trim();
            string Password = GTextBoxPassword.Text.Trim();

            var LoginTitanGym = UserBL.LoginTitanGYM(Username, Password);

            if (LoginTitanGym.IsAuthenticated)
            {
                if (GCheckBoxRememberMe.Checked)
                    Utility.RememberMe(Username, Password);
                else Utility.DeleteFile();

                LunchTitanGymAfterLogin(LoginTitanGym.UserID);
            }
            else MessageBox.Show(LoginTitanGym.Message, "Message Titan GYM", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void GGradientButtonLogin_Click(object sender, EventArgs e)
        {
            LoginTitanGym();
        }

        private void UCLoginTitanGym_Load(object sender, EventArgs e)
        {
            string username = "", password = "";

            if (Utility.GetUsernameAndPasswordFromFileRememberMe(ref username, ref password))
            {
                GCheckBoxRememberMe.Checked = true;
                GTextBoxUsername.Text = username;
                GTextBoxPassword.Text = password;
            }


        }
    }
}
