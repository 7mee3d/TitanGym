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

        public static bool FindEmploymentStatusesBy(string EmploymentStatusesName, ref byte EmploymentStatusesID)
        {


            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


		                    
                            SELECT *
                            FROM EmploymentStatuses
                            WHERE NameEmploymentStatus = @NameEmploymentStatus ;
    
            
                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<string>("@NameEmploymentStatus", EmploymentStatusesName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;
                            EmploymentStatusesID = reader.GetTheValueFrom<byte>("EmploymentStatusID");
                        }
                }

            }

            return Founded;
        }

        public static bool FindEmploymentStatusesBy(byte EmploymentStatusID, ref string EmploymentStatusesName)
        {


            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


		                    
                            SELECT *
                            FROM EmploymentStatuses
                            WHERE EmploymentStatusID = @EmploymentStatusID ;
    
            
                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@EmploymentStatusID", EmploymentStatusID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;
                            EmploymentStatusesName = reader.GetTheValueFrom<string>("NameEmploymentStatus");
                        }
                }

            }

            return Founded;
        }
    }
}
