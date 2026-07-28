using System.Data;
using TitanGym_DataAccessLayer.Trainer_Assignments;

namespace TitanGym_BusinessLayer.Trainer_AssignmentsBL
{
    public class TrainerAssignmentsBL
    {

        public static DataTable GetAllTrainerAssignments()
            => TrainerAssignmentsDALQueries.GetAllTrainerAssignments();

    }
}
