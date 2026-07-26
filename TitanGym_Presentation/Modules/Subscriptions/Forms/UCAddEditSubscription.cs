using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MembershipsBL;
using TitanGym_BusinessLayer.Subscription_StatusesBL;
using TitanGym_BusinessLayer.SubscriptionBL;

namespace TitanGym_Presentation.Modules.Subscriptions.Forms
{
    public partial class UCAddEditSubscription : UserControl
    {
        private SubscriptionBL _InformationSubscription;
        private double _TotalSubFees = 0.0d;
        private int _SubscriptionID = -1;

        public event Action<bool> FinishedAddEditSubscription;

        private enum _EnSubscriptionMode
        {
            _kADD_NEW_SUBSCRIPTION = 1,
            _kUPDATE_INFORMATION_SUBSCRIPTION = 2
        };

        private _EnSubscriptionMode _ModeSubscription;

        public UCAddEditSubscription()
        {
            InitializeComponent();
            _ModeSubscription = _EnSubscriptionMode._kADD_NEW_SUBSCRIPTION;
        }

        public UCAddEditSubscription(int subcriptionID)
        {
            InitializeComponent();
            _ModeSubscription = _EnSubscriptionMode._kUPDATE_INFORMATION_SUBSCRIPTION;
            _SubscriptionID = subcriptionID;
        }

        private void _HandleTheDateTime()
        {
            GDateTimePickerStartDate.MinDate = DateTime.Now;
            GDateTimePickerEndDate.MinDate = GDateTimePickerStartDate.MinDate;
            GDateTimePickerEndDate.Value = GDateTimePickerStartDate.MinDate;
            GDateTimePickerEndDate.Value = GDateTimePickerStartDate.MinDate;
        }

        private void _DefaultValues()
        {
            _LoadMembershipsTypeInCB();
            _LoadSubscriptionStatusesInCB();

            if (_ModeSubscription == _EnSubscriptionMode._kADD_NEW_SUBSCRIPTION)
            {
                _InformationSubscription = new SubscriptionBL();
                lblSubscriptionTitle.Text = "Add New Subscription";
                GGButtonAddNewSubscription.Text = "Add Subscription";
                _HandleTheDateTime();
                return;
            }

            _InformationSubscription = SubscriptionBL.FindTheSubscriptionBy(_SubscriptionID);

            if (_InformationSubscription is null)
            {
                MessageBox.Show("This subscription is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlShowInformationMemberWithFilter1.EnableControls = false;
        }

        private void _LoadInformatioNSubscriptionInControls()
        {

            GComboBoxSubscriptionStatus.SelectedValue = _InformationSubscription.SubscriptionStatusID;
            GComboBoxMembershipType.SelectedValue = _InformationSubscription.MembershipID;
            GDateTimePickerEndDate.Value = _InformationSubscription.EndDate;
            GDateTimePickerStartDate.Value = _InformationSubscription.StartDate;
            GTextBoxSubscriptionFees.Text = _InformationSubscription.SubscriptionFees.ToString();

            GDateTimePickerStartDate.Enabled = false;
            ctrlShowInformationMemberWithFilter1.LoadInformationMember(_InformationSubscription.MemberID);

        }

        private void _LoadMembershipsTypeInCB()
        {
            GComboBoxMembershipType.DataSource = MembershipBL.GetAllInformationMembershipPlans();
            GComboBoxMembershipType.DisplayMember = "MembershipName";
            GComboBoxMembershipType.ValueMember = "MembershipID";
        }

        private void _LoadSubscriptionStatusesInCB()
        {
            GComboBoxSubscriptionStatus.DataSource = SubscriptionStatusBL.GetAllSubscriptionStatuses();
            GComboBoxSubscriptionStatus.DisplayMember = "NameSubscriptionStatus";
            GComboBoxSubscriptionStatus.ValueMember = "SubscriptionStatusID";
        }

        private void _PrepareInformationSubscription()
        {
            _InformationSubscription.SubscriptionStatusID = Convert.ToByte(GComboBoxSubscriptionStatus.SelectedValue);
            _InformationSubscription.StartDate = GDateTimePickerStartDate.Value;
            _InformationSubscription.EndDate = GDateTimePickerEndDate.Value;
            _InformationSubscription.MembershipID = Convert.ToInt32(GComboBoxMembershipType.SelectedValue);
            _InformationSubscription.MemberID = ctrlShowInformationMemberWithFilter1.MemberID;
            _InformationSubscription.SubscriptionFees = _TotalSubFees;
        }

        private bool _ValidationDateTime()
        {
            DateTime DTStart = new DateTime(GDateTimePickerStartDate.Value.Year, GDateTimePickerStartDate.Value.Month, GDateTimePickerStartDate.Value.Day);
            DateTime DTEnd = new DateTime(GDateTimePickerEndDate.Value.Year, GDateTimePickerEndDate.Value.Month, GDateTimePickerEndDate.Value.Day);

            if (DTStart > DTEnd)
                return false;

            if (DTStart == DTEnd)
                return false;

            return true;
        }

        private bool _PrepareContraintsSubscription()
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


            if (ctrlShowInformationMemberWithFilter1.MemberID == -1)
            {
                MessageBox.Show(
                         "You must selected Member according the filter",
                         "Message Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                  );

                return false;
            }

            if (!_ValidationDateTime())
            {
                MessageBox.Show(
                                       "Please , enter the valid date",
                                       "Message Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error
                                );

                return false;
            }

            return true;
        }


        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void GGButtonAddNewSubscription_Click(object sender, EventArgs e)
        {
            if (!_PrepareContraintsSubscription()) return;

            _PrepareInformationSubscription();

            if (this._InformationSubscription.SaveModeSubscription())
            {
                FinishedAddEditSubscription?.Invoke(true);

                if (_ModeSubscription == _EnSubscriptionMode._kADD_NEW_SUBSCRIPTION)
                    MessageBox.Show("The subscription added sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The subscription updated sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("The subscription added/updated faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lblSubscriptionTitle.Text = "Update Subscription";
            GGButtonAddNewSubscription.Text = "Update Subscription";
            this._ModeSubscription = _EnSubscriptionMode._kUPDATE_INFORMATION_SUBSCRIPTION;
            ctrlShowInformationMemberWithFilter1.EnableControls = false;

        }

        private void UCAddEditSubscription_Load(object sender, EventArgs e)
        {
            _DefaultValues();

            if (this._ModeSubscription == _EnSubscriptionMode._kUPDATE_INFORMATION_SUBSCRIPTION)
                _LoadInformatioNSubscriptionInControls();
        }

        private void GComboBoxMembershipType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GComboBoxMembershipType.SelectedValue == null)
                return;

            if (!(GComboBoxMembershipType.SelectedValue is int))
                return;

            int membershipID = (int)GComboBoxMembershipType.SelectedValue;

            var membership = MembershipBL.FindMembershipBy(membershipID);

            if (membership == null)
                return;

            _TotalSubFees = membership.MonthlyPrice;
            GTextBoxSubscriptionFees.Text = _TotalSubFees.ToString();
        }

    }
}
