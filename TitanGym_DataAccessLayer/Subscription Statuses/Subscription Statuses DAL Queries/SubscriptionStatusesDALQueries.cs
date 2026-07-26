using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using TitanGym_DataAccessLayer.Helper;

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

        public static bool FindSubscriptionStatusBy(
            byte subscriptionStatusID,
            ref string nameSubscriptionStatus
            )
        {

            bool IsFounded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                    SELECT *
                                    FROM SubscriptionStatuses
                                    WHERE SubscriptionStatusID = @SubscriptionStatusID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@SubscriptionStatusID", subscriptionStatusID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFounded = true;
                            nameSubscriptionStatus = reader.GetTheValueFrom<string>("NameSubscriptionStatus");

                        }

                }

            }

            return IsFounded;
        }
    }
}
