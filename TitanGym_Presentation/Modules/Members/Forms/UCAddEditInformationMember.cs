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

        public class SpeacialInfoMemberEventArgs : EventArgs
        {
            public bool IsAddOrEditMember { get; private set; }
            public int NewMemberID { get; private set; }

            public SpeacialInfoMemberEventArgs(bool isAddOrEditMember, int newMemberID)
            {
                this.IsAddOrEditMember = isAddOrEditMember;
                this.NewMemberID = newMemberID;
            }

        }

        public event Action<SpeacialInfoMemberEventArgs> EH_FinishedAddEditMember;



        public UCAddEditInformationMember()
        {
            InitializeComponent();
            this._Mode = _EnModeMembers._kADD_NEW_MEMBER;
        }


        public UCAddEditInformationMember(int memberID)
        {
            InitializeComponent();
            this._MemberID = memberID;
            this._Mode = _EnModeMembers._kUPDATE_INFORMATION_MEMBER;
        }

        private void UCAddEditInformationMember_Load(object sender, EventArgs e)
        {
            _PrepareDefaultsValuesMember();
            ctrlShowInformationPersonByFilter1.FocusTheTextBoxPersonID();

            if (this._Mode == _EnModeMembers._kUPDATE_INFORMATION_MEMBER)
                _LoadDataMemberInControls();

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

            this._InformationMember = MemberBL.FindTheMemberBy(_MemberID);

            if (this._InformationMember == null) return;

            ctrlShowInformationPersonByFilter1.EnableControls = false;
            this._Mode = _EnModeMembers._kUPDATE_INFORMATION_MEMBER;
            lblTitlePerson.Text = "Update Member";
            GGButtonAddNewMember.Text = "Update Member";
        }

        private void _LoadDataMemberInControls()
        {
            GTextBoxEmergencyContactName.Text = this._InformationMember.EmergencyContactName;
            GTextBoxEmergencyContactPhoneNumber.Text = this._InformationMember.EmergencyContactPhoneNumber;
            ctrlShowInformationPersonByFilter1.LoadInformationPerson(this._InformationMember.PersonID);
            ctrlShowInformationPersonByFilter1.EnableControls = false;
        }

        private void _PrepareInformationMember()
        {
            this._InformationMember.RegistrationDate = DateTime.Now;
            this._InformationMember.EmergencyContactName = GTextBoxEmergencyContactName.Text.Trim();
            this._InformationMember.EmergencyContactPhoneNumber = GTextBoxEmergencyContactPhoneNumber.Text.Trim();
            this._InformationMember.PersonID = ctrlShowInformationPersonByFilter1.PersonID;
            this._InformationMember.MembershipStatusID = MemberBL.enMembershipStatus._kACTIVE;
        }

        private void GTextBoxValidating(object sender, CancelEventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProviderMemberSection.SetError(textBox, "This Field Empty");
            }
            else e.Cancel = false;
        }

        private void GTextBoxEmergencyContactPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
           => e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));

        private void ctrlShowInformationPersonByFilter1_EHFinishedSearchPerson(object sender, int e)
        {
            int PersonID = e;

            if (PersonID == -1) return;

            this._PersonID = PersonID;

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


            if (this._PersonID == -1 && ctrlShowInformationPersonByFilter1.PersonID == -1)
            {
                MessageBox.Show(
                         "You must selected person according the filter",
                         "Message Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                  );

                return false;
            }


            if (this._InformationMember.IsMemberActiveAndExistsBy())
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

            if (this._InformationMember.SaveModeMember())
            {
                this.EH_FinishedAddEditMember?.Invoke(new SpeacialInfoMemberEventArgs(true, this._InformationMember.MemberID));

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
