using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Subscriptions
{
    public class SubscriptionDALQueries
    {

        public static bool FindTheSubscriptionBy(

             int SubscriptionID,
             ref DateTime StartDate,
             ref DateTime EndDate,
             ref double SubscriptionFees,
             ref byte SubscriptionStatusID,
             ref int MemberID,
             ref int MembershipID

            )
        {


            bool IsFounded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                            SELECT *
                            FROM Subscriptions
                            WHERE SubscriptionID = @SubscriptionID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@SubscriptionID", SubscriptionID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFounded = true;

                            StartDate = reader.GetTheValueFrom<DateTime>("StartDate");
                            EndDate = reader.GetTheValueFrom<DateTime>("EndDate");
                            SubscriptionFees = reader.GetTheValueFrom<double>("SubscriptionFees");
                            SubscriptionStatusID = reader.GetTheValueFrom<byte>("SubscriptionStatusID");
                            MemberID = reader.GetTheValueFrom<int>("MemberID");
                            MembershipID = reader.GetTheValueFrom<int>("MembershipID");
                        }
                }

            }

            return IsFounded;
        }
    }
}
