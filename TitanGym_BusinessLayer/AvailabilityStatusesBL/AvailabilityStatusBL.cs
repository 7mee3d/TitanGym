
using System.Data;
using TitanGym_DataAccessLayer.Availability_Statuses;

namespace TitanGym_BusinessLayer.AvailabilityStatusesBL
{
    public class AvailabilityStatusBL
    {

        public byte AvailabilityStatusID { get; set; }
        public string NameAvailabilityStatus { get; set; }

        public AvailabilityStatusBL(byte availabilityStatusID, string nameAvailabilityStatus)
        {
            this.AvailabilityStatusID = availabilityStatusID;
            this.NameAvailabilityStatus = nameAvailabilityStatus;
        }

        public AvailabilityStatusBL()
        {
            this.AvailabilityStatusID = default;
            this.NameAvailabilityStatus = default;
        }

        public static AvailabilityStatusBL FindTheAvailabilityStatus(byte AvailabilityStatusID)
        {

            string NameAvailabilityStatus = "";

            bool Founded = AvailabilityStatusesDALQueries.FindTheAvailabilityStatusBy(AvailabilityStatusID, ref NameAvailabilityStatus);

            if (Founded)
                return new AvailabilityStatusBL(AvailabilityStatusID, NameAvailabilityStatus);
            else
                return null;

        }


        public static DataTable GetAllInformationAvailabilityStatus()
            => AvailabilityStatusesDALQueries.GetAllAvailabilityStatus();
    }
}
