
using System;
using System.Data;
using TitanGym_DataAccessLayer.Payments;

namespace TitanGym_BusinessLayer.PaymentsBL
{
    public class PaymentsBL
    {
        //PaymentID	SubscriptionID	PaymentDate	Amount	Note	PaymentMethodID	PaymentStatusID

        public int PaymentID { get; set; }
        public int SubscriptionID { get; set; }
        public byte PaymentMethodID { get; set; }
        public byte PaymentStatusID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }

        public PaymentsBL(

            int paymentID,
            int subscriptionID,
            byte paymentMethodID,
            byte paymentStatusID,
            DateTime paymentDate,
            double amount,
            string note

            )
        {
            this.PaymentID = paymentID;
            this.SubscriptionID = subscriptionID;
            this.PaymentMethodID = paymentMethodID;
            this.PaymentStatusID = paymentStatusID;
            this.PaymentDate = paymentDate;
            this.Amount = amount;
            this.Note = note;
        }

        public PaymentsBL()
        {
            this.PaymentID = default;
            this.SubscriptionID = default;
            this.PaymentMethodID = default;
            this.PaymentStatusID = default;
            this.PaymentDate = default;
            this.Amount = default;
            this.Note = default;
        }

        public static PaymentsBL FindPaymentBy(int SubscriptionID)
        {
            int PaymentID = 0;

            DateTime PaymentDate = DateTime.Now;
            double Amount = 0.0d;
            string Note = "";
            byte PaymentMethodID = 0, PaymentStatusID = 0;

            bool IsFounded = PaymentsDALQueries.FindThePaymentBy(SubscriptionID, ref PaymentID, ref PaymentDate, ref Amount, ref Note, ref PaymentMethodID, ref PaymentStatusID);

            if (IsFounded)
                return new PaymentsBL(PaymentID, SubscriptionID, PaymentMethodID, PaymentStatusID, PaymentDate, Amount, Note);
            else
                return null;

        }

        public static DataTable GetAllPayments()
            => PaymentsDALQueries.GetAllPayemnts();
    }
}
