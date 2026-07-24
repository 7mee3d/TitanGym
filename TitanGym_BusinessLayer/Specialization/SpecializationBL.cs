

using System.Data;
using TitanGym_DataAccessLayer.Specialization;

namespace TitanGym_BusinessLayer.Specialization
{
    public class SpecializationBL
    {

        public string SpecializationName { get; set; }
        public byte SpecializationID { get; set; }


        public SpecializationBL(string specializationName, byte specializationID)
        {
            this.SpecializationName = specializationName;
            this.SpecializationID = specializationID;
        }

        public SpecializationBL()
        {
            this.SpecializationName = default;
            this.SpecializationID = default;
        }

        public static SpecializationBL FindTheSpecializationBy(string SpecializationName)
        {

            byte SpecializationID = 0;

            bool Founded = SpecializationDALQueries.FindSpecializationBy(SpecializationName, ref SpecializationID);

            if (Founded)
                return new SpecializationBL(SpecializationName, SpecializationID);
            else
                return null;

        }

        public static DataTable GetAllSpecializations()
            => SpecializationDALQueries.GetAllSpecializations();

    }
}
