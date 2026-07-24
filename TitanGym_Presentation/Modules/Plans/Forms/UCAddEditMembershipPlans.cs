using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.AvailabilityStatusesBL;
using TitanGym_BusinessLayer.MembershipsBL;

namespace TitanGym_Presentation.Modules.Plans.Forms
{
    public partial class UCAddEditMembershipPlans : UserControl
    {
        private enum _EnModeMembershipPlan
        {
            _kADD_NEW_MEMBERSHIP_PLAN = 1,
            _kUPDATE_INFORMATION_MEMBERSHIP_PLAN = 2
        };
        public event Action<bool> FinishedAddEditMembershipPlan;

        private _EnModeMembershipPlan _ModeMembership;
        private MembershipBL _InformationMembership;

        public UCAddEditMembershipPlans()
        {
            InitializeComponent();
            _ModeMembership = _EnModeMembershipPlan._kADD_NEW_MEMBERSHIP_PLAN;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _LoadInformationAvaAvailabilityStatusesToCB()
        {
            GComboBoxAvailabilityStatuses.DataSource = AvailabilityStatusBL.GetAllInformationAvailabilityStatus();
            GComboBoxAvailabilityStatuses.DisplayMember = "NameAvailabilityStatus";
            GComboBoxAvailabilityStatuses.ValueMember = "AvailabilityStatusID";
        }

        private void _DefaultValuesMemberships()
        {
            _LoadInformationAvaAvailabilityStatusesToCB();

            if (_ModeMembership == _EnModeMembershipPlan._kADD_NEW_MEMBERSHIP_PLAN)
            {
                _InformationMembership = new MembershipBL();
                lblTitleMembershipPlan.Text = "Add New Plan";
                GGButtonAddNewPlan.Text = "Add Plan";
                return;

            }

        }

        private void _PrepareInformationMembershipPlan()
        {
            _InformationMembership.Duration = Convert.ToByte(GTextBoxDuration.Text.Trim());
            _InformationMembership.MonthlyPrice = Convert.ToDouble(GTextBoxMonthlySalary.Text.Trim());
            _InformationMembership.Description = GTextBoxDescription.Text.Trim();
            _InformationMembership.AvailabilityStatusID = Convert.ToByte(GComboBoxAvailabilityStatuses.SelectedValue);
            _InformationMembership.MembershipName = GTextBoxMembershipName.Text.Trim();
        }

        private bool _PrepareContraintsMembershipPlans()
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

            if (this._ModeMembership == _EnModeMembershipPlan._kADD_NEW_MEMBERSHIP_PLAN)
                if (MembershipBL.IsMembershipPlanNameExists(GTextBoxMembershipName.Text.Trim()))
                {
                    MessageBox.Show(
                      "This Membership name already exists , Try enter new membership name",
                      "Message Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                      );
                    return false;
                }
            /*
            if (Convert.ToByte(GTextBoxDuration.Text.Trim()) > 12)
            {
                MessageBox.Show(
                  "This duration connot added",
                  "Message Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );
                return false;
            }
            */
            return true;

        }

        private void _AddNewMembershipPlan()
        {
            if (!_PrepareContraintsMembershipPlans()) return;

            _PrepareInformationMembershipPlan();


            if (_InformationMembership.SaveModeMembershipPlan())
            {
                FinishedAddEditMembershipPlan?.Invoke(true);
                if (_ModeMembership == _EnModeMembershipPlan._kADD_NEW_MEMBERSHIP_PLAN)
                    MessageBox.Show("The membership plan added sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The membership plan updated sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("The membership plan added/updated Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _ModeMembership = _EnModeMembershipPlan._kUPDATE_INFORMATION_MEMBERSHIP_PLAN;
            lblTitleMembershipPlan.Text = "Update Plan";
            GGButtonAddNewPlan.Text = "Update Plan";
        }

        private void GGButtonCancel_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void GGButtonAddNewTrainer_Click(object sender, EventArgs e)
        {
            _AddNewMembershipPlan();
        }

        private void UCAddEditMembershipPlans_Load(object sender, EventArgs e)
        {
            _DefaultValuesMemberships();
        }

        private void GTextBoxDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void GTextBoxMonthlySalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.');
        }

        private void GTextBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Guna2TextBox G2TB = sender as Guna2TextBox;

            if (string.IsNullOrWhiteSpace(G2TB.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderMembershipPlan.SetError(G2TB, "This field is empty");

            }
            else e.Cancel = false;
        }
    }
}
