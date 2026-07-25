
using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Availability_Statuses
{
    public class AvailabilityStatusesDALQueries
    {

        public static DataTable GetAllAvailabilityStatus()
        {

            DataTable DT_AllAvailabilityStatuses = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                SELECT *
                                FROM AvailabilityStatuses


                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllAvailabilityStatuses.Load(reader);

                }


            }

            return DT_AllAvailabilityStatuses;
        }

        public static bool FindTheAvailabilityStatusBy(byte AvailabilityStatusID, ref string AvailabilityStatusName)
        {

            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                SELECT *
                                FROM AvailabilityStatuses
                                WHERE AvailabilityStatusID = @AvailabilityStatusID


                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@AvailabilityStatusID", AvailabilityStatusID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;
                            AvailabilityStatusName = reader.GetTheValueFrom<string>("NameAvailabilityStatus");
                        }

                }


            }

            return Founded;
        }
    }
}
