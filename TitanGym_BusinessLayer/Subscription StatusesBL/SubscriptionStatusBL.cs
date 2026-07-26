using System.Data;
using TitanGym_DataAccessLayer.Subscription_Statuses;

namespace TitanGym_BusinessLayer.Subscription_StatusesBL
{
    public class SubscriptionStatusBL
    {
        //SubscriptionStatusID	NameSubscriptionStatus

        public byte SubscriptionStatusID { get; set; }
        public string NameSubscriptionStatus { get; set; }

        public SubscriptionStatusBL(byte subscriptionStatusID, string nameSubscriptionStatus)
        {
            this.SubscriptionStatusID = subscriptionStatusID;
            this.NameSubscriptionStatus = nameSubscriptionStatus;
        }

        public SubscriptionStatusBL()
        {
            this.SubscriptionStatusID = default;
            this.NameSubscriptionStatus = default;
        }

        public static SubscriptionStatusBL FindTheSubscriptionStatusBy(byte SubscriptionStatusID)
        {

            string nameSubscriptionStatus = "";

            bool IsFounded = SubscriptionStatusesDALQueries.FindSubscriptionStatusBy(SubscriptionStatusID, ref nameSubscriptionStatus);

            if (IsFounded)
                return new SubscriptionStatusBL(SubscriptionStatusID, nameSubscriptionStatus);
            else return null;

        }

        public static DataTable GetAllSubscriptionStatuses()
            => SubscriptionStatusesDALQueries.GetAllSubscriptionsStatus();
    }
}
