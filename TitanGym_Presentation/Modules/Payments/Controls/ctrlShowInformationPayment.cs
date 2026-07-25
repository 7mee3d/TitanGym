using System.Windows.Forms;
using TitanGym_BusinessLayer.PaymentsBL;

namespace TitanGym_Presentation.Modules.Payments.Controls
{
    public partial class ctrlShowInformationPayment : UserControl
    {
        public ctrlShowInformationPayment()
        {
            InitializeComponent();
        }

        private PaymentsBL _InformationPayment;

        private void _DefualtValues()
        {
            lblPaymentID.Text = "[???]";
            lblSubscriptionID.Text = "[???]";
            lblPaymentMethod.Text = "[???]";
            lblPaymentStatus.Text = "[???]";
            lblNotes.Text = "[???]";
            lblAmount.Text = "[???]";
            lblPaymentDate.Text = "[???]";
            lblMembershipPlan.Text = "[???]";
        }

        public void LoadInformationPayment(int paymentID)
        {

            if (paymentID <= 0) return;

            _InformationPayment = PaymentsBL.FindPaymentBy(paymentID);

            if (_InformationPayment is null)
            {
                _DefualtValues();
                MessageBox.Show("This payment is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblPaymentID.Text = _InformationPayment.PaymentID.ToString();
            lblSubscriptionID.Text = _InformationPayment.SubscriptionID.ToString();
            lblPaymentMethod.Text = _InformationPayment.InformationPaymentMethod.NamePaymentMethod;
            lblPaymentStatus.Text = _InformationPayment.InformationPaymentStatus.NamePaymentStatus;
            lblNotes.Text = _InformationPayment.Note;
            lblAmount.Text = _InformationPayment.Amount.ToString("C");
            lblPaymentDate.Text = _InformationPayment.PaymentDate.ToString("dd/MM/yyyy");
            lblMembershipPlan.Text = _InformationPayment.InformationSubscription.InformationMembership.MembershipName;

            int PersonID = _InformationPayment.InformationSubscription.InformationMember.PersonID;
            ctrlShowInformationPerson1.LoadInformationPerson(PersonID);

        }


    }
}
