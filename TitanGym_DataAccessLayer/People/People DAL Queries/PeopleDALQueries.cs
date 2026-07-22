using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.People
{
    public class PeopleDALQueries
    {

        public static DataTable GetAllPeople()
        {

            DataTable DT_AllPeople = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"
                                            
                                    SELECT   
                                        PersonID ,
                                        FirstName,
                                        SecondName,
                                        ThirdName,
                                        LastName,
                                        Gender,
                                        PhoneNumber,
                                        EmailAddress,
                                        ResidentialAddress,
                                        DateOfBirth

                                    FROM People ;

                                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllPeople.Load(reader);
                }
            }

            return DT_AllPeople;
        }

        public static bool DeletePerson(int personID)
        {

            bool IsDeletePerson = false;


            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                                DELETE FROM People
                                WHERE PersonID = @PersonID

                             ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@PersonID", personID);

                    connection.Open();

                    IsDeletePerson = command.ExecuteNonQuery() > 0;

                }
            }

            return IsDeletePerson;
        }

        public static bool FindThePersonBy(

            int PersonID,
                ref string firstName,
                ref string secondName,
                ref string thirdName,
                ref string lastName,
                ref char gender,
                ref string phoneNumber,
                ref string emailAddress,
                ref string residentialAddress,
                ref DateTime dateOfBirth,
                ref string imagePath
    )
        {

            bool FoundedPerson = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                            SELECT
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

                            FROM People

                            WHERE PersonID = @PersonID;

                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.AddWithParameter<int>("@PersonID", PersonID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            FoundedPerson = true;
                            firstName = reader.GetTheValueFrom<string>("FirstName");
                            secondName = reader.GetTheValueFrom<string>("SecondName");
                            thirdName = reader.GetTheValueFrom<string>("ThirdName");
                            lastName = reader.GetTheValueFrom<string>("LastName");
                            gender = reader.GetTheValueFrom<char>("Gender");
                            phoneNumber = reader.GetTheValueFrom<string>("PhoneNumber");
                            emailAddress = reader.GetTheValueFrom<string>("EmailAddress");
                            residentialAddress = reader.GetTheValueFrom<string>("ResidentialAddress");
                            dateOfBirth = reader.GetTheValueFrom<DateTime>("DateOfBirth");
                            imagePath = reader.GetTheValueFrom<string>("ImagePath");
                        }

                    }


                }


            }

            return FoundedPerson;
        }
    }
}
