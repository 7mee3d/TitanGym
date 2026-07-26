using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Subscriptions
{
    public class SubscriptionsDALCommands
    {

        public static int InsertNewSubscription(

            DateTime startDate,
            DateTime endDate,
            double subscriptionFees,
            byte subscriptionStatusID,
            int memberID,
            int membershipID

            )
        {



            int SubscriptionID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"

                                    INSERT INTO Subscriptions
                                    (
                                        StartDate,
                                        EndDate,
                                        SubscriptionFees,
                                        SubscriptionStatusID,
                                        MemberID,
                                        MembershipID
                                    )
                                    VALUES
                                    (
                                        @StartDate,
                                        @EndDate,
                                        @SubscriptionFees,
                                        @SubscriptionStatusID,
                                        @MemberID,
                                        @MembershipID
                                    );


                                    SELECT SCOPE_IDENTITY();


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<DateTime>("@StartDate", startDate);
                    command.AddWithParameter<DateTime>("@EndDate", endDate);
                    command.AddWithParameter<double>("@SubscriptionFees", subscriptionFees);
                    command.AddWithParameter<byte>("@SubscriptionStatusID", subscriptionStatusID);
                    command.AddWithParameter<int>("@MemberID", memberID);
                    command.AddWithParameter<int>("@MembershipID", membershipID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        SubscriptionID = ID;

                }

            }

            return SubscriptionID;
        }

        public static bool UpdateInformationSubscription(
            int subscriptionID,
            DateTime startDate,
            DateTime endDate,
            double subscriptionFees,
            byte subscriptionStatusID,
            int memberID,
            int membershipID

            )
        {



            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"

                                    UPDATE Subscriptions
                                   
                                    SET
                                        StartDate = @StartDate,
                                        EndDate = @EndDate,
                                        SubscriptionFees = @SubscriptionFees,
                                        SubscriptionStatusID = @SubscriptionStatusID,
                                        MemberID = @MemberID,
                                        MembershipID = @MembershipID
                                  


                                    WHERE SubscriptionID = @SubscriptionID


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<DateTime>("@StartDate", startDate);
                    command.AddWithParameter<DateTime>("@EndDate", endDate);
                    command.AddWithParameter<double>("@SubscriptionFees", subscriptionFees);
                    command.AddWithParameter<byte>("@SubscriptionStatusID", subscriptionStatusID);
                    command.AddWithParameter<int>("@MemberID", memberID);
                    command.AddWithParameter<int>("@MembershipID", membershipID);
                    command.AddWithParameter<int>("@SubscriptionID", subscriptionID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    IsUpdated = command.ExecuteNonQuery() > 0;


                }

            }

            return IsUpdated;
        }
    }
}
