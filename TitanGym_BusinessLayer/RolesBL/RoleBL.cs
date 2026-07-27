
using System.Data;
using TitanGym_DataAccessLayer.Roles;

namespace TitanGym_BusinessLayer.RolesBL
{
    public class RoleBL
    {
        public static DataTable GetAllRoles()
            => RolesDALQueries.GetAllRoles();
    }
}
