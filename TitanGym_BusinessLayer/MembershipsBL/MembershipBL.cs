using System.Data;
using TitanGym_DataAccessLayer.Memberships;

namespace TitanGym_BusinessLayer.MembershipsBL
{
    public class MembershipBL
    {

        public static DataTable GetAllInformationMembershipPlans()
            => MembershipsDALQueries.GetAllMembershipPlans();
    }
}
