using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Payment_Statuses
{
    public class PaymentStatusDALQueries
    {

        public static bool FindPaymentStatusBy(

            byte PaymentStatusID,
            ref string NamePaymentStatus

            )
        {

            bool IsFounded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                        SELECT *
                        FROM PaymentStatuses
                        WHERE PaymentStatusID = @PaymentStatusID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@PaymentStatusID", PaymentStatusID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFounded = true;
                            NamePaymentStatus = reader.GetTheValueFrom<string>("NamePaymentStatus");
                        }
                }
            }

            return IsFounded;
        }


        public static DataTable GetAllPaymentStatus()
        {

            DataTable DT_AllPaymentStatus = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"



                         SELECT *
                        FROM PaymentStatuses


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllPaymentStatus.Load(reader);
                }



            }

            return DT_AllPaymentStatus;
        }

    }
}
