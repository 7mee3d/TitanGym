
using System.Data;
using System.Data.SqlClient;

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
    }
}
