

using System.Data;
using TitanGym_DataAccessLayer.Users;

namespace TitanGym_BusinessLayer.UsersBL
{
    public class UserBL
    {

        public static DataTable GetAllUsers()
            => UsersDALQueries.GetAllUsers();
    }
}
