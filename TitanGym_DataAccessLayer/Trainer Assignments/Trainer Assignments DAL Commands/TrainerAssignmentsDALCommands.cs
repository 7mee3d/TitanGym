

using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Trainer_Assignments
{
    public class TrainerAssignmentsDALCommands
    {

        public static int InsertNewAssigementTrainer(
                DateTime assignmentDate,
                string note,
                int trainerID,
                int memberID

            )
        {

            int AssigementTrainerID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"


                        INSERT INTO TrainerAssignments
                                                        (
                                                        
                                                        AssignmentDate,
                                                        Note, 
                                                        TrainerID,
                                                        MemberID
                                                        
                                                        ) 

                                                       VALUES

                                                        (

                                                        @AssignmentDate,
                                                        @Note, 
                                                        @TrainerID,
                                                        @MemberID

                                                        );

                         SELECT SCOPE_IDENTITY();

                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<DateTime>("@AssignmentDate", assignmentDate);
                    command.AddWithParameter<string>("@Note", note);
                    command.AddWithParameter<int>("@TrainerID", trainerID);
                    command.AddWithParameter<int>("@MemberID", memberID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        AssigementTrainerID = ID;


                }
            }

            return AssigementTrainerID;
        }

        public static bool UpdateInformatioNTrianerAssigement(
                int TrainerAssigementID,
                DateTime assignmentDate,
                string note,
                int trainerID,
                int memberID

            )
        {

            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"


                        UPDATE TrainerAssignments
                                                      
                         SET
                                                        AssignmentDate = @AssignmentDate,
                                                        Note = @Note, 
                                                        TrainerID = @TrainerID,
                                                        MemberID = @MemberID


                        WHERE TrainerAssignmentID = @TrainerAssignmentID;
                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@TrainerAssignmentID", TrainerAssigementID);
                    command.AddWithParameter<DateTime>("@AssignmentDate", assignmentDate);
                    command.AddWithParameter<string>("@Note", note);
                    command.AddWithParameter<int>("@TrainerID", trainerID);
                    command.AddWithParameter<int>("@MemberID", memberID);

                    connection.Open();

                    IsUpdated = command.ExecuteNonQuery() > 0;


                }
            }

            return IsUpdated;
        }
    }
}
