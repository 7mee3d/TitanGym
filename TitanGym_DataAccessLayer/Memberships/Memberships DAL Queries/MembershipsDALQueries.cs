using System;
using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Memberships
{
    public class MembershipsDALQueries
    {

        public static DataTable GetAllMembershipPlans()
        {
            DataTable DT_AllInformationMembershipPlans = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                               SELECT

                                        MShip.MembershipID ,
                                        MShip.MembershipName ,
                                        MShip.Duration , 
                                        MShip.MonthlyPrice ,
                                        MShip.Description ,
                                        AStatus.NameAvailabilityStatus
                                    
                              FROM Memberships MShip
                              INNER JOIN AvailabilityStatuses AStatus 
                              ON AStatus.AvailabilityStatusID = MShip.AvailabilityStatusID

                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllInformationMembershipPlans.Load(reader);
                }


            }

            return DT_AllInformationMembershipPlans;
        }

        public static bool IsMembershipExistsBy(string MembershipName)
        {

            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                    SELECT FOUND = 1 
                                    FROM Memberships MEM
                                    WHERE MEM.MembershipName  = @MembershipName


                 ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<string>("@MembershipName", MembershipName);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    IsExists = result != null && Convert.ToBoolean(result);

                }
            }

            return IsExists;
        }
    }
}
