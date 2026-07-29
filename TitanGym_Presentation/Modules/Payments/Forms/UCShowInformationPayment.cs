using System;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Payments.Forms
{
    public partial class UCShowInformationPayment : UserControl
    {
        private int _PaymentID = -1;
        public event Action<bool> FinishedShowInfoPayment;

        public UCShowInformationPayment(int paymentID)
        {
            InitializeComponent();
            _PaymentID = paymentID;
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCShowInformationPayment_Load(object sender, EventArgs e)
        {
            ctrlShowInformationPayment1.LoadInformationPayment(_PaymentID);
            FinishedShowInfoPayment?.Invoke(false);
        }


    }
}
