using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Account_Statuses
{
    public class AccountStatusesDALQueries
    {
        public static bool FindTheAccountStatusBy(
         byte AccountStatusID,
         ref string AccountStatusName
         )
        {


            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"



                        SELECT *
                        FROM AccountStatuses 
                        WHERE AccountStatusID = @AccountStatusID

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<byte>("@AccountStatusID", AccountStatusID);
                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            IsFound = true;
                            AccountStatusName = reader.GetTheValueFrom<string>("AccountStatusName");
                        }
                }


            }

            return IsFound;
        }

        public static DataTable GetAllAccountStatuses()
        {

            DataTable DT_AllAccountStatuses = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                        SELECT *
                        FROM AccountStatuses

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllAccountStatuses.Load(reader);

                }
            }

            return DT_AllAccountStatuses;
        }
    }
}
