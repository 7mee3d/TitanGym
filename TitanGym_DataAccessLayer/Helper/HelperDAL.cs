namespace TitanGym_DataAccessLayer.Helper
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="HelperDAL" />
    /// </summary>
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

        /// <summary>
        /// The Add With Parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="YourCommand">The YourCommand<see cref="SqlCommand"/></param>
        /// <param name="columnName">The columnName<see cref="string"/></param>
        /// <param name="valueColumn">The valueColumn<see cref="T"/></param>
        public static void AddWithParameter<T>(this SqlCommand YourCommand, string columnName, T valueColumn) =>
            YourCommand.Parameters.AddWithValue(columnName, valueColumn);

        /// <summary>
        /// The Get The Value From Table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="YourReader">The YourReader<see cref="SqlDataReader"/></param>
        /// <param name="columnName">The columnName<see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        public static T GetTheValueFrom<T>(this SqlDataReader YourReader, string columnName)
            => YourReader[columnName] != DBNull.Value ? (T)Convert.ChangeType(YourReader[columnName], typeof(T)) : (T)default;
    }
}
