using System.Data;
using TitanGym_DataAccessLayer.Employment_Statuses;

namespace TitanGym_BusinessLayer.Employment_StatusesBL
{
    public class EmploymentStatusesBL
    {

        public byte EmploymentStatusesID { get; set; }
        public string EmploymentStatusesName { get; set; }

        public EmploymentStatusesBL(byte employmentStatusesID, string employmentStatusesName)
        {
            this.EmploymentStatusesID = employmentStatusesID;
            this.EmploymentStatusesName = employmentStatusesName;
        }

        public static EmploymentStatusesBL FindEmploymentStatuesBy(string EmploymentStatuesName)
        {
            byte EmploymentStatuesID = 0;

            bool Founded = EmploymentStatusesDALQueries.FindEmploymentStatusesBy(EmploymentStatuesName, ref EmploymentStatuesID);
            if (Founded)
                return new EmploymentStatusesBL(EmploymentStatuesID, EmploymentStatuesName);
            else return null;
        }

        public static EmploymentStatusesBL FindEmploymentStatuesBy(byte employmentStatusesID)
        {
            string EmploymentStatuesName = "";

            bool Founded = EmploymentStatusesDALQueries.FindEmploymentStatusesBy(employmentStatusesID, ref EmploymentStatuesName);
            if (Founded)
                return new EmploymentStatusesBL(employmentStatusesID, EmploymentStatuesName);
            else return null;
        }

        public static DataTable GetAllEmploymentStatuses()
            => EmploymentStatusesDALQueries.GetAllEmploymentStatuses();

    }
}
