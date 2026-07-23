using System.Data;
using TitanGym_DataAccessLayer.Employment_Statuses;

namespace TitanGym_BusinessLayer.Employment_StatusesBL
{
    public class EmploymentStatusesBL
    {

        public static DataTable GetAllEmploymentStatuses()
            => EmploymentStatusesDALQueries.GetAllEmploymentStatuses();

    }
}
