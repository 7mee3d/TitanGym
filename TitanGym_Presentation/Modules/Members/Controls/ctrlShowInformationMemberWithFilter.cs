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

        private void _DefaultValues()
        {
            ctrlShowInformationMember1._DefaultValuesMember();
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
