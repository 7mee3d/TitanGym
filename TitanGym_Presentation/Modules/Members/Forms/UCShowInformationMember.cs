using System;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Members.Forms
{
    public partial class UCShowInformationMember : UserControl
    {
        private int _MemberID = -1;
        public event Action<bool> EH_FinishedShowInfoMember;

        public UCShowInformationMember(int memberID)
        {
            InitializeComponent();
            _MemberID = memberID;
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCShowInformationMember_Load(object sender, EventArgs e)
        {
            ctrlShowInformationMember1.LoadInformationMember(_MemberID);
            EH_FinishedShowInfoMember?.Invoke(false);

        }
    }
}
