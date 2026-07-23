using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Employment_Statuses
{
    public class EmploymentStatusesDALQueries
    {

        public static DataTable GetAllEmploymentStatuses()
        {
            DataTable DT_AllEmploymentStatuses = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                            SELECT *
                            FROM EmploymentStatuses

                      ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllEmploymentStatuses.Load(reader);
                }


            }

            return DT_AllEmploymentStatuses;
        }
    }
}
