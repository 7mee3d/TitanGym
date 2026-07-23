using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;

namespace TitanGym_Presentation.Modules.Members.Forms
{
    public partial class UCAddEditInformationMember : UserControl
    {

        private enum _EnModeMembers : byte
        {
            _kADD_NEW_MEMBER = 1,
            _kUPDATE_INFORMATION_MEMBER = 2
        }

        private int _MemberID = -1;
        private int _PersonID = -1;
        private _EnModeMembers _Mode;
        private MemberBL _InformationMember;


        public UCAddEditInformationMember()
        {
            InitializeComponent();
            _Mode = _EnModeMembers._kADD_NEW_MEMBER;
        }


        public UCAddEditInformationMember(int memberID)
        {
            InitializeComponent();
            _MemberID = memberID;
            _Mode = _EnModeMembers._kUPDATE_INFORMATION_MEMBER;
        }

        private void UCAddEditInformationMember_Load(object sender, EventArgs e)
        {
            _PrepareDefaultsValuesMember();
            ctrlShowInformationPersonByFilter1.FocusTheTextBoxPersonID();

        }

        private void _PrepareDefaultsValuesMember()
        {
            if (_Mode == _EnModeMembers._kADD_NEW_MEMBER)
            {
                _InformationMember = new MemberBL();
                GGButtonAddNewMember.Text = "Add Member";
                lblTitlePerson.Text = "Add New Member";
                return;

            }


        }
        private void _PrepareInformationMember()
        {
            _InformationMember.RegistrationDate = DateTime.Now;
            _InformationMember.EmergencyContactName = GTextBoxEmergencyContactName.Text.Trim();
            _InformationMember.EmergencyContactPhoneNumber = GTextBoxEmergencyContactPhoneNumber.Text.Trim();
            _InformationMember.PersonID = _PersonID;
            _InformationMember.MembershipStatusID = MemberBL.enMembershipStatus._kACTIVE;
        }

        private void GTextBoxValidating(object sender, CancelEventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProviderMemberSection.SetError(textBox, "This Field Empty");
            }
            e.Cancel = false;
        }

        private void GTextBoxEmergencyContactPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
           => e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));

        private void ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson(object sender, int e)
        {
            int PersonID = e;

            if (PersonID == -1) return;

            _PersonID = PersonID;

        }

        private bool _PrepareContraintMemberSection()
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

            if (_PersonID == -1)
            {
                MessageBox.Show(
                         "You must selected person according the filter",
                         "Message Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                  );

                return false;
            }

            if (_InformationMember.IsMemberActiveAndExistsBy())
            {
                MessageBox.Show(
                        "This member already Active",
                        "Message Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                 );

                return false;
            }

            return true;
        }

        private void _AddNewMember()
        {
            _PrepareInformationMember();

            if (!_PrepareContraintMemberSection()) return;



            if (_InformationMember.SaveModeMember())
            {
                if (this._Mode == _EnModeMembers._kADD_NEW_MEMBER)
                    MessageBox.Show("The Member Addedd Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Member Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("The Member Addedd/Updated Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this._Mode = _EnModeMembers._kUPDATE_INFORMATION_MEMBER;
            lblTitlePerson.Text = "Update Member";
            GGButtonAddNewMember.Text = "Update Member";
        }

        private void GGButtonAddNewMember_Click(object sender, EventArgs e)
        {
            _AddNewMember();
        }

        private void GGButtonCancel_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }
    }
}
