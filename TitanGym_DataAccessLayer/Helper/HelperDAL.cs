using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanGym_DataAccessLayer.Helper
{
    public class HelperDAL
    {
        /// <summary>
        /// Gets the Connection String DVLD
        /// </summary>
        public static string TitanGymConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TitanGymConnectionString"].ConnectionString;
            }
        }
    }
}
