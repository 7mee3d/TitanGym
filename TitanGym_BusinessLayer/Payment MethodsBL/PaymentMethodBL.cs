

using TitanGym_DataAccessLayer.Payment_Methods;

namespace TitanGym_BusinessLayer.Payment_MethodsBL
{
    public class PaymentMethodBL
    {

        //PaymentMethodID NamePaymentMethod

        public byte PaymentMethodID { get; set; }
        public string NamePaymentMethod { get; set; }

        public PaymentMethodBL(byte paymentMethodID, string namePaymentMethod)
        {
            PaymentMethodID = paymentMethodID;
            NamePaymentMethod = namePaymentMethod;
        }

        public PaymentMethodBL()
        {
            this.PaymentMethodID = default;
            this.NamePaymentMethod = default;
        }

        public static PaymentMethodBL FindPaymentMethodBy(byte paymentMethodID)
        {
            string NamePaymentMethod = "";

            bool IsFounded = PaymentMethodDALQueries.FindThePaymentMethodBy(paymentMethodID, ref NamePaymentMethod);

            if (IsFounded)
                return new PaymentMethodBL(paymentMethodID, NamePaymentMethod);
            else return null;
        }

    }
}
