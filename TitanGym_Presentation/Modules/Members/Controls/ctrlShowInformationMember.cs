using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;

namespace TitanGym_Presentation.Modules.Members.Controls
{
    public partial class ctrlShowInformationMember : UserControl
    {
        public ctrlShowInformationMember()
        {
            InitializeComponent();
        }

        private MemberBL _MemberInfo;

        public MemberBL MemberInformation { get => _MemberInfo; }

        private void _DefaultValuesMember()
        {
            lblEmergencyContactName.Text = "[???]";
            label.Text = "[???]";
        }

        public void LoadInformationMember(int MemberID)
        {
            _MemberInfo = MemberBL.FindTheMemberBy(MemberID);

            if (_MemberInfo is null)
            {
                _DefaultValuesMember();
                MessageBox.Show("This member not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblEmergencyContactName.Text = _MemberInfo.EmergencyContactName;
            lblEmergencyContactPhoneNumber.Text = _MemberInfo.EmergencyContactPhoneNumber;
            lblMemberID.Text = _MemberInfo.MemberID.ToString();
            ctrlShowInformationPerson1.LoadInformationPerson(_MemberInfo.PersonID);
        }
    }
}
