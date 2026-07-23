

using System.Data;
using TitanGym_DataAccessLayer.Specialization;

namespace TitanGym_BusinessLayer.Specialization
{
    public class SpecializationBL
    {

        public static DataTable GetAllSpecializations()
            => SpecializationDALQueries.GetAllSpecializations();
    }
}
