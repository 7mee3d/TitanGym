using System;
using System.Data;
using TitanGym_DataAccessLayer.Trainer_Assignments;

namespace TitanGym_BusinessLayer.Trainer_AssignmentsBL
{
    public class TrainerAssignmentsBL
    {
        //TrainerAssignmentID	AssignmentDate	Note	TrainerID	MemberID

        public enum EnModeTrainerAssigements : byte
        {
            _kASSIGEMENT_MEMBER_TO_TRAINER = 1,
            _kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TRAINER = 2
        };


        public int TrainerAssignmentID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Note { get; set; }
        public int TrainerID { get; set; }
        public int MemberID { get; set; }
        public EnModeTrainerAssigements ModeAssigementTrainer { get; private set; }

        public TrainerAssignmentsBL(

            int trainerAssignmentID,
            DateTime assignmentDate,
            string note,
            int trainerID,
            int memberID
            )
        {
            this.TrainerAssignmentID = trainerAssignmentID;
            this.AssignmentDate = assignmentDate;
            this.Note = note;
            this.TrainerID = trainerID;
            this.MemberID = memberID;
            this.ModeAssigementTrainer = EnModeTrainerAssigements._kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TRAINER;
        }


        public TrainerAssignmentsBL()
        {
            this.TrainerAssignmentID = default;
            this.AssignmentDate = default;
            this.Note = default;
            this.TrainerID = default;
            this.MemberID = default;
            this.ModeAssigementTrainer = EnModeTrainerAssigements._kASSIGEMENT_MEMBER_TO_TRAINER;
        }

        private bool _AddAssigementTrainer()
        {
            this.TrainerAssignmentID = TrainerAssignmentsDALCommands.InsertNewAssigementTrainer(AssignmentDate, Note, TrainerID, MemberID);
            return this.TrainerAssignmentID != -1;
        }

        private bool UpdateInformatioNTrainerAssigement()
        {
            return TrainerAssignmentsDALCommands.UpdateInformatioNTrianerAssigement(TrainerAssignmentID, AssignmentDate, Note, TrainerID, MemberID);
        }

        public static TrainerAssignmentsBL FindTheTrainerAssigementBy(int TrainerAssigementID)
        {


            DateTime assignmentDate = DateTime.Now;
            string note = "";
            int trainerID = 0, memberID = 0;

            bool IsFound = TrainerAssignmentsDALQueries.FindTheTrainerAssigements(TrainerAssigementID, ref assignmentDate, ref note, ref trainerID, ref memberID);
            if (IsFound)
                return new TrainerAssignmentsBL(TrainerAssigementID, assignmentDate, note, trainerID, memberID);
            else return null;
        }



        public bool SaveModeAssigmentTrainer()
        {

            switch (this.ModeAssigementTrainer)
            {
                case EnModeTrainerAssigements._kASSIGEMENT_MEMBER_TO_TRAINER:
                    if (_AddAssigementTrainer())
                    {
                        this.ModeAssigementTrainer = EnModeTrainerAssigements._kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TRAINER;
                        return true;
                    }

                    return false;

                case EnModeTrainerAssigements._kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TRAINER:
                    return UpdateInformatioNTrainerAssigement();

                default: return false;
            }

        }

        public static DataTable GetAllTrainerAssignments()
            => TrainerAssignmentsDALQueries.GetAllTrainerAssignments();

        public static int GetTotalMemberAssigementsTrainers()
            => TrainerAssignmentsDALQueries.GetTotalMembersAssigementsWithTrainers();

    }
}
