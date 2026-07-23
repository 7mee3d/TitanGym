

using System.Data;
using TitanGym_DataAccessLayer.Members;

namespace TitanGym_BusinessLayer.MemberBL
{
    public class MemberBL
    {

        public static DataTable GetAllMembers()
            => MemberDALQueries.GetAllMembers();

        public static int GetTheMembersPendingExpireBy(int DayPendingExpire)
            => MemberDALQueries.GetTotalThePendingExpireMembershipMembers(DayPendingExpire);
    }
}
