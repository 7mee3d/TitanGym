

using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.People.People_DAL_Commands
{
    public class PeopleDALCommands
    {

        public static int InsertNewPerson(

            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            char gender,
            string phoneNumber,
            string emailAddress,
            string residentialAddress,
            DateTime dateOfBirth,
            string imagePath


            )
        {

            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                                INSERT INTO People
                                (
                                            FirstName,
                                            SecondName,
                                            ThirdName,
                                            LastName,
                                            Gender,
                                            PhoneNumber,
                                            EmailAddress,
                                            ResidentialAddress,
                                            DateOfBirth,
                                	        ImagePath
                                )
                                VALUES

                                (

                                            @FirstName , 
                                            @SecondName, 
                                            @ThirdName, 
                                            @LastName, 
                                            @Gender, 
                                            @PhoneNumber,
                                            @EmailAddress,
                                            @ResidentialAddress,
                                            @DateOfBirth ,
                                            @ImagePath

                                  );
                                
                                SELECT SCOPE_IDENTITY ();



                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.AddWithParameter<string>("@FirstName", firstName);
                    command.AddWithParameter<string>("@SecondName", secondName);
                    command.AddWithParameter<string>("@ThirdName", thirdName);
                    command.AddWithParameter<string>("@LastName", lastName);
                    command.AddWithParameter<char>("@Gender", gender);
                    command.AddWithParameter<string>("@PhoneNumber", phoneNumber);
                    command.AddWithParameter<string>("@EmailAddress", emailAddress);
                    command.AddWithParameter<string>("@ResidentialAddress", residentialAddress);
                    command.AddWithParameter<DateTime>("@DateOfBirth", dateOfBirth);
                    if (string.IsNullOrWhiteSpace(imagePath))
                        command.AddWithParameter<object>("@ImagePath", DBNull.Value);
                    else command.AddWithParameter<string>("@ImagePath", imagePath);

                    connection.Open();


                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        PersonID = ID;

                }
            }

            return PersonID;

        }


    }
}
