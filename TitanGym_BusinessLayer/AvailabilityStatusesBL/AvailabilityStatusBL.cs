
using System.Data;
using TitanGym_DataAccessLayer.Availability_Statuses;

namespace TitanGym_BusinessLayer.AvailabilityStatusesBL
{
    public class AvailabilityStatusBL
    {

        public static DataTable GetAllInformationAvailabilityStatus()
            => AvailabilityStatusesDALQueries.GetAllAvailabilityStatus();
    }
}
