

using System;
using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Users
{
    public class UsersDALQueries
    {


        public static DataTable GetAllUsers()
        {

            DataTable DT_AllUsers = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                        SELECT
                        
                            US.UserID ,
                            US.PersonID ,
                            CONCAT(PEOP.FirstName , ' ' , PEOP.SecondName , ' ' , PEOP.ThirdName , ' ' , PEOP.LastName) AS FullNamePerson ,
                            US.Username ,
                            US.CreationDateUser ,
                            ACCSTATUS.AccountStatusName ,
                            RO.RoleName
                        
                        FROM Users US
                        INNER JOIN People PEOP
                        ON PEOP.PersonID = US.PersonID
                        INNER JOIN AccountStatuses ACCSTATUS
                        ON ACCSTATUS.AccountStatusID = US.AccountStatusID 
                        INNER JOIN Roles RO
                        ON RO.RoleID = US.RoleID 



                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllUsers.Load(reader);
                }
            }

            return DT_AllUsers;
        }

        public static bool IsUserExistsBy(string Username)
        {

            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"



                                SELECT FOUND = 1 
                                FROM Users
                                WHERE LOWER (Users.Username ) = LOWER (@Username);


            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<string>("@Username", Username);
                    connection.Open();



                    object result = command.ExecuteScalar();

                    IsExists = result != null && Convert.ToBoolean(result);

                }


            }

            return IsExists;
        }
    }
}
