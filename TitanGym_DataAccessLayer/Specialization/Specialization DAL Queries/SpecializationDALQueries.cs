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
                                        SpecializationName	
                                       

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

        public static bool FindSpecializationBy(string SpecializationName, ref byte SpecializationID)
        {


            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


		                     SELECT 
                                        SpecializationID,
                                        SpecializationName	
                                       

			                 FROM Specializations
                             WHERE SpecializationName = @SpecializationName ;
    
            
                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<string>("@SpecializationName", SpecializationName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;
                            SpecializationID = reader.GetTheValueFrom<byte>("SpecializationID");
                        }
                }

            }

            return Founded;
        }

        public static bool FindSpecializationBy(byte SpecializationID, ref string SpecializationName)
        {


            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


		                     SELECT 
                                        SpecializationID,
                                        SpecializationName	
                                       

			                 FROM Specializations
                             WHERE SpecializationID = @SpecializationID ;
    
            
                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<byte>("@SpecializationID", SpecializationID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;
                            SpecializationName = reader.GetTheValueFrom<string>("SpecializationName");
                        }
                }

            }

            return Founded;
        }
    }
}
