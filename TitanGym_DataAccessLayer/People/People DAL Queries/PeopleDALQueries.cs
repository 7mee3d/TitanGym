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
                                            
                                    SELECT *
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
    }
}
