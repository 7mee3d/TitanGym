using System;

using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Users.Forms
{
    public partial class UCShowInformationUser : UserControl
    {
        private int _UserID = -1;
        public event Action<bool> FinishedShowInfoUser;

        public UCShowInformationUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCShowInformationUser_Load(object sender, EventArgs e)
        {
            ctrlShowInformationUser1.LoadInformationUser(_UserID);
            FinishedShowInfoUser?.Invoke(false);
        }
    }
}
