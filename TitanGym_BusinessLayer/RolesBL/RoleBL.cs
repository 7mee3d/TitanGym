using System.Data;
using TitanGym_DataAccessLayer.Roles;

namespace TitanGym_BusinessLayer.RolesBL
{
    public class RoleBL
    {

        public byte RoleID { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; }
        public int PermissionsRole { get; set; }

        public RoleBL(

            byte roleID,
            string roleName,
            bool roleStatus,
            int permissionsRole

            )
        {
            this.RoleID = roleID;
            this.RoleName = roleName;
            this.RoleStatus = roleStatus;
            this.PermissionsRole = permissionsRole;
        }

        public RoleBL()
        {
            this.RoleID = default;
            this.RoleName = default;
            this.RoleStatus = default;
            this.PermissionsRole = default;
        }

        public static RoleBL FindTheRoleBy(byte roleID)
        {
            string roleName = "";
            bool roleStatus = false;
            int permissionsRole = 0;

            bool IsFound = RolesDALQueries.FindTheRoleBy(roleID, ref roleName, ref roleStatus, ref permissionsRole);

            if (IsFound)
                return new RoleBL(roleID, roleName, roleStatus, permissionsRole);
            else return null;
        }

        public static DataTable GetAllRoles()
            => RolesDALQueries.GetAllRoles();
    }
}
