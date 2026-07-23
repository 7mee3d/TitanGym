using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Specialization
{
    public class SpecializationDALQueries
    {

        public static DataTable GetAllSpecializations()
        {


            DataTable DT_AllSpecializations = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


		                     SELECT 
                                        SpecializationID,
                                        SpecializationName	,
                                        ISNULL ( Salary , 0 )  AS Salary

			                 FROM Specializations
    
            
                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllSpecializations.Load(reader);

                }

            }

            return DT_AllSpecializations;
        }
    }
}
