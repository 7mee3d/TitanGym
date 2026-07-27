using System.Data;
using System.Data.SqlClient;

namespace TitanGym_DataAccessLayer.Account_Statuses
{
    public class AccountStatusesDALQueries
    {

        public static DataTable GetAllAccountStatuses()
        {

            DataTable DT_AllAccountStatuses = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                        SELECT *
                        FROM AccountStatuses

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllAccountStatuses.Load(reader);

                }
            }

            return DT_AllAccountStatuses;
        }
    }
}
