using System;
using System.Data;
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

        public static bool FindTheSubscriptionBy(

              int MemberID,
             ref int SubscriptionID,
             ref DateTime StartDate,
             ref DateTime EndDate,
             ref double SubscriptionFees,
             ref byte SubscriptionStatusID,
             ref int MembershipID

            )
        {


            bool IsFounded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                            SELECT *
                            FROM Subscriptions
                            WHERE MemberID = @MemberID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@MemberID", MemberID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFounded = true;

                            SubscriptionID = reader.GetTheValueFrom<int>("SubscriptionID");
                            StartDate = reader.GetTheValueFrom<DateTime>("StartDate");
                            EndDate = reader.GetTheValueFrom<DateTime>("EndDate");
                            SubscriptionFees = reader.GetTheValueFrom<double>("SubscriptionFees");
                            SubscriptionStatusID = reader.GetTheValueFrom<byte>("SubscriptionStatusID");
                            MembershipID = reader.GetTheValueFrom<int>("MembershipID");
                        }
                }

            }

            return IsFounded;
        }

        public static DataTable GetAllSubscription()
        {

            DataTable DT_AllInformationSubscription = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                        SELECT 
                        
                             SUB.SubscriptionID ,
                             MEM.MemberID ,
                             MEMSHIP.MembershipID , 
                             CONCAT (PEOP.FirstName , ' ' , PEOP.SecondName , ' ' , PEOP.ThirdName , ' ' , PEOP.LastName)  AS MemberName,
                             MEMSHIP.MembershipName , 
                             MEMSHIP.Duration,
                             SUB.StartDate , 
                             SUB.EndDate ,
                             SUB.SubscriptionFees , 
                             SUBSTATUS.NameSubscriptionStatus 
                        
                        FROM Subscriptions SUB

                        INNER JOIN Members MEM 
                        ON MEM.MemberID = SUB.MemberID 

                        INNER JOIN Memberships MEMSHIP 
                        ON MEMSHIP.MembershipID = SUB.MembershipID

                        INNER JOIN People PEOP
                        ON PEOP.PersonID = MEM.PersonID 

                        INNER JOIN SubscriptionStatuses SUBSTATUS 
                        ON SUBSTATUS.SubscriptionStatusID = SUB.SubscriptionStatusID


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllInformationSubscription.Load(reader);
                }
            }

            return DT_AllInformationSubscription;
        }

        public static bool IsMemberHasSubscriptionActive(int MemberID)
        {

            bool IsHasActiveMember = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {


                string Query = @"



                                        SELECT FOUND = 1 
                                        FROM Subscriptions SUB
                                        WHERE SUB.MemberID = @MemberID AND SUB.SubscriptionStatusID = 1

                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@MemberID", MemberID);
                    connection.Open();

                    object result = command.ExecuteScalar();

                    IsHasActiveMember = result != null && Convert.ToBoolean(result);

                }
            }

            return IsHasActiveMember;
        }
    }
}
