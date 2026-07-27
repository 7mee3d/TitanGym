using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

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

        public static bool FindTheRoleBy(
            byte RoleID,
            ref string RoleName,
            ref bool RoleStatus,
            ref int PermissionsRole
            )
        {

            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                            SELECT *
                            FROM Roles 
                            WHERE RoleID = @RoleID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<byte>("@RoleID", RoleID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFound = true;

                            RoleName = reader.GetTheValueFrom<string>("RoleName");
                            RoleStatus = reader.GetTheValueFrom<bool>("RoleStatus");
                            PermissionsRole = reader.GetTheValueFrom<int>("PermissionsRole");
                        }
                }

            }

            return IsFound;
        }
    }
}
