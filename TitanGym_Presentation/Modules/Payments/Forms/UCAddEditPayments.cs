using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.Payment_MethodsBL;
using TitanGym_BusinessLayer.Payment_StatusesBL;
using TitanGym_BusinessLayer.PaymentsBL;

namespace TitanGym_Presentation.Modules.Payments.Forms
{
    public partial class UCAddEditPayments : UserControl
    {

        private enum _EnPaymentsMode
        {
            _kADD_NEW_PAYMENT = 1,
            _UPDATE_INFORMATION_PAYMENT = 2
        };

        private _EnPaymentsMode _ModePayment;
        private PaymentsBL _InformationPayment;
        private int _SubscriptionID = -1;
        public event Action<bool> FinishedAddEditPayment;

        public UCAddEditPayments()
        {
            InitializeComponent();
            _ModePayment = _EnPaymentsMode._kADD_NEW_PAYMENT;
        }

        private void _LoadInformationPaymentMethodsInCB()
        {

            GComboBoxPaymentMethods.DisplayMember = "NamePaymentMethod";
            GComboBoxPaymentStatus.ValueMember = "PaymentMethodID";
            GComboBoxPaymentMethods.DataSource = PaymentMethodBL.GetAllPaymentMethods();
        }

        private void _LoadInformationPaymentStatusesInCB()
        {

            GComboBoxPaymentStatus.DisplayMember = "NamePaymentStatus";
            GComboBoxPaymentStatus.ValueMember = "PaymentStatusID";
            GComboBoxPaymentStatus.DataSource = PaymentStatusesBL.GetAllPaymentStatus();
        }

        private void _DefaultValues()
        {
            _LoadInformationPaymentMethodsInCB();
            _LoadInformationPaymentStatusesInCB();


            if (this._ModePayment == _EnPaymentsMode._kADD_NEW_PAYMENT)
            {
                _InformationPayment = new PaymentsBL();
                lblTitlePayment.Text = "Add New Payment";
                GGButtonAddNewPayment.Text = "Add Payment";
                return;
            }
        }

        private void _PrepareInformationPayment()
        {
            _InformationPayment.Note = GTextBoxNote.Text.Trim();
            _InformationPayment.SubscriptionID = ctrlShowInformationSubscriptionByFilter1.SubscriptionID;
            _InformationPayment.PaymentMethodID = Convert.ToByte(GComboBoxPaymentMethods.SelectedValue);
            _InformationPayment.PaymentStatusID = Convert.ToByte(GComboBoxPaymentStatus.SelectedValue);
            _InformationPayment.Amount = Convert.ToDouble(GTextBoxAmount.Text.Trim());
            _InformationPayment.PaymentDate = DateTime.Now;

        }

        private bool _PrepareContraintsPayment()
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

            if (ctrlShowInformationSubscriptionByFilter1.SubscriptionID == -1)
            {
                MessageBox.Show(
                                "Must select subcription",
                                "Message Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                return false;
            }

            return true;
        }


        private void _AddNewPayment()
        {

            if (!_PrepareContraintsPayment()) return;

            _PrepareInformationPayment();

            if (_InformationPayment.SavePaymentMode())
            {
                FinishedAddEditPayment?.Invoke(true);

                if (this._ModePayment == _EnPaymentsMode._kADD_NEW_PAYMENT)
                    MessageBox.Show("The payment added successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The payment updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("The payment added Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void GGButtonAddNewPayment_Click(object sender, EventArgs e)
        {
            _AddNewPayment();

        }

        private void UCAddEditPayments_Load(object sender, EventArgs e)
        {
            _DefaultValues();
        }

        private void GTextBoxAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GTextBoxAmount.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderPayment.SetError(GTextBoxAmount, "This Feild is empty");
            }
            else
                e.Cancel = false;
        }

        private void GTextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void GGButtonCancel_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }
    }
}
