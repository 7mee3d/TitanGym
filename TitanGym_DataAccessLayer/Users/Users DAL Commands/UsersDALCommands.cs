using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Users
{
    public class UsersDALCommands
    {

        public static int InsertNewUser(

                    string username,
                    string password,
                    DateTime creationDateUser,
                    byte accountStatusID,
                    int personID,
                    int roleID
            )
        {


            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"



                                INSERT INTO Users
                                (
                                    username,
                                    password,
                                    creationDateUser,
                                    accountStatusID,
                                    personID,
                                    roleID
                                )
                                VALUES
                                (
                                    @username,
                                    @password,
                                    GETDATE(),
                                    @accountStatusID,
                                    @personID,
                                    @roleID
                                );
                                
                                SELECT SCOPE_IDENTITY();


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<string>("@username", username);
                    command.AddWithParameter<string>("@password", password);
                    //command.AddWithParameter<DateTime>("@creationDateUser", creationDateUser);
                    command.AddWithParameter<byte>("@accountStatusID", accountStatusID);
                    command.AddWithParameter<int>("@personID", personID);
                    command.AddWithParameter<int>("@roleID", roleID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        UserID = ID;



                }
            }

            return UserID;
        }



    }
}
