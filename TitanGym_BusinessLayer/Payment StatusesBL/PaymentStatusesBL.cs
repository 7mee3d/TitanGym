

using TitanGym_DataAccessLayer.Payment_Statuses;

namespace TitanGym_BusinessLayer.Payment_StatusesBL
{
    public class PaymentStatusesBL
    {
        //PaymentStatusID	NamePaymentStatus

        public byte PaymentStatusID { get; set; }
        public string NamePaymentStatus { get; set; }

        public PaymentStatusesBL(

            byte paymentStatusID,
            string namePaymentStatus

            )
        {
            this.PaymentStatusID = paymentStatusID;
            this.NamePaymentStatus = namePaymentStatus;
        }

        public PaymentStatusesBL()
        {
            this.PaymentStatusID = default;
            this.NamePaymentStatus = default;
        }

        public static PaymentStatusesBL FindPaymentStatusBy(byte paymentStatusID)
        {

            string NamePaymentStatus = "";

            bool IsFounded = PaymentStatusDALQueries.FindPaymentStatusBy(paymentStatusID, ref NamePaymentStatus);

            if (IsFounded)
                return new PaymentStatusesBL(paymentStatusID, NamePaymentStatus);
            else return null;
        }
    }
}
