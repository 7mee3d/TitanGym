using System.Data;
using TitanGym_DataAccessLayer.Subscription_Statuses;

namespace TitanGym_BusinessLayer.Subscription_StatusesBL
{
    public class SubscriptionStatusBL
    {

        public static DataTable GetAllSubscriptionStatuses()
            => SubscriptionStatusesDALQueries.GetAllSubscriptionsStatus();
    }
}
