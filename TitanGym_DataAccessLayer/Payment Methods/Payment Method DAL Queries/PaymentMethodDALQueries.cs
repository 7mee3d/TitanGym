using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Payment_Methods
{
    public class PaymentMethodDALQueries
    {
        public static bool FindThePaymentMethodBy(
                byte PaymentMethodID,
                ref string NamePaymentMethod
            )
        {


            bool IsFounded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                            SELECT *
                            FROM PaymentMethods
                            WHERE PaymentMethodID = @PaymentMethodID
                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@PaymentMethodID", PaymentMethodID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFounded = true;
                            NamePaymentMethod = reader.GetTheValueFrom<string>("NamePaymentMethod");
                        }

                }

            }

            return IsFounded;
        }
    }
}
