using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;
using TitanGym_Presentation.Modules.Members.Forms;

namespace TitanGym_Presentation.Modules.Members.Controls
{
    public partial class ctrlShowInformationMemberWithFilter : UserControl
    {

        private MemberBL _InformationMember;

        public ctrlShowInformationMemberWithFilter()
        {
            InitializeComponent();
        }

        private int _MemberID = -1;
        public int MemberID { get { return _MemberID; } }
        private void _DefaultValues()
        {
            ctrlShowInformationMember1._DefaultValuesMember();
        }

        private bool _EnableControls;

        public bool EnableControls
        {
            set
            {
                _EnableControls = value;

                GGButtonAddNewMember.Enabled = _EnableControls;
                GGButtonSearchMember.Enabled = _EnableControls;
                GTextBoxMemberID.Enabled = _EnableControls;

            }
        }

        private void GGButtonSearchMember_Click(object sender, EventArgs e)
        {
            int MemberID = Convert.ToInt32(GTextBoxMemberID.Text.Trim());

            _InformationMember = MemberBL.FindTheMemberBy(MemberID);

            if (_InformationMember is null)
            {
                _DefaultValues();
                MessageBox.Show("This member is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowInformationMember1.LoadInformationMember(MemberID);
            _MemberID = MemberID;
        }

        public void LoadInformationMember(int memberID)
        {

            if (memberID <= 0) return;

            _InformationMember = MemberBL.FindTheMemberBy(memberID);

            if (_InformationMember is null)
            {
                _DefaultValues();
                MessageBox.Show("This member is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowInformationMember1.LoadInformationMember(memberID);
            _MemberID = memberID;

        }

        private void GGButtonAddNewMember_Click(object sender, EventArgs e)
        {
            var ucAddEditInformationMember = new UCAddEditInformationMember();

            ucAddEditInformationMember.EH_FinishedAddEditMember += result =>
            {
                if (result.IsAddOrEditMember)
                {
                    int NewMemberID = result.NewMemberID;
                    ctrlShowInformationMember1.LoadInformationMember(NewMemberID);
                    GTextBoxMemberID.Text = NewMemberID.ToString();
                }
            };

            AppNavigator.Show(ucAddEditInformationMember);

        }
    }
}
