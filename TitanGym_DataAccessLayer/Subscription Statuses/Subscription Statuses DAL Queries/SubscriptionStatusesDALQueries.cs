using System.Data;
using System.Data.SqlClient;

namespace TitanGym_DataAccessLayer.Subscription_Statuses
{
    public class SubscriptionStatusesDALQueries
    {


        public static DataTable GetAllSubscriptionsStatus()
        {
            DataTable DT_AllSubscriptionStatus = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                    SELECT *
                                    FROM SubscriptionStatuses

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllSubscriptionStatus.Load(reader);
                }

            }
            return DT_AllSubscriptionStatus;
        }
    }
}
