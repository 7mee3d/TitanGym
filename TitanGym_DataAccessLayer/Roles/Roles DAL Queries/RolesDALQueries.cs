using System.Data;
using System.Data.SqlClient;

namespace TitanGym_DataAccessLayer.Roles
{
    public class RolesDALQueries
    {


        public static DataTable GetAllRoles()
        {

            DataTable DT_AllRoles = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                                            
                                    SELECT *
                                    FROM Roles 


                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllRoles.Load(reader);

                }
            }

            return DT_AllRoles;
        }
    }
}
