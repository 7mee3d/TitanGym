

using System.Data;
using System.Data.SqlClient;

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
                            US.Password ,
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
    }
}
