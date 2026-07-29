using System.Data;
using TitanGym_DataAccessLayer.Account_Statuses;

namespace TitanGym_BusinessLayer.Account_StatusesBL
{
    public class AccountStatusBL
    {



        public byte AccountStatusID { get; set; }
        public string AccountStatusName { get; set; }

        public AccountStatusBL(

            byte accountStatusID,
            string accountStatusName

            )
        {
            this.AccountStatusID = accountStatusID;
            this.AccountStatusName = accountStatusName;
        }

        public AccountStatusBL()
        {
            this.AccountStatusID = default;
            this.AccountStatusName = default;
        }

        public static AccountStatusBL FindTheAccountStatusBy(byte accountStatusID)
        {
            string AccountStatusName = "";

            bool IsFound = AccountStatusesDALQueries.FindTheAccountStatusBy(accountStatusID, ref AccountStatusName);

            if (IsFound)
                return new AccountStatusBL(accountStatusID, AccountStatusName);
            else return null;


        }

        public static DataTable GetAllAccountStatuses()
            => AccountStatusesDALQueries.GetAllAccountStatuses();
    }
}
