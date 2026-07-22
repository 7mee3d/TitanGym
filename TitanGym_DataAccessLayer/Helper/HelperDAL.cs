using System.Configuration;
using System.Data.SqlClient;


namespace TitanGym_DataAccessLayer.Helper
{
    public static class HelperDAL
    {
        /// <summary>
        /// Gets the Connection String Titan Gym 
        /// </summary>
        public static string TitanGymConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TitanGymConnectionString"].ConnectionString;
            }
        }

        public static void AddWithParameter<T>(this SqlCommand YourCommand, string columnName, T valueColumn) =>
            YourCommand.Parameters.AddWithValue(columnName, valueColumn);

    }
}
