using System.Data;
using TitanGym_DataAccessLayer.People;

namespace TitanGym_BusinessLayer.PeopleBL
{
    public class PeopleBL
    {
        public static DataTable GetAllPeople() => PeopleDALQueries.GetAllPeople();

    }
}
