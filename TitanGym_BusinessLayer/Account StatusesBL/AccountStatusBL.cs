
using System.Data;
using TitanGym_DataAccessLayer.Account_Statuses;

namespace TitanGym_BusinessLayer.Account_StatusesBL
{
    public class AccountStatusBL
    {


        public static DataTable GetAllAccountStatuses()
            => AccountStatusesDALQueries.GetAllAccountStatuses();
    }
}
