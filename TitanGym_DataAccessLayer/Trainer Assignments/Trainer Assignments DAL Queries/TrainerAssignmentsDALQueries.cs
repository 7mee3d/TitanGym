using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Trainer_Assignments
{
    public class TrainerAssignmentsDALQueries
    {

        public static DataTable GetAllTrainerAssignments()
        {


            DataTable DT_AllTrainerAssignments = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {


                string Query = @"


                            SELECT
                            
                                    TRAAss.TrainerAssignmentID ,
                                    TRAAss.MemberID , 
                                    CONCAT (PEOP.FirstName , ' ' , PEOP.SecondName , ' ' , PEOP.ThirdName , ' ' , PEOP.LastName) AS TrainerName ,
                                    CONCAT (PEOP2.FirstName , ' ' , PEOP2.SecondName , ' ' , PEOP2.ThirdName , ' ' , PEOP2.LastName) AS MemberName ,
                                    MEMShip.MembershipName ,
                                    SUB.StartDate , 
                                    SUB.EndDate ,
                                    TRAAss.Note 
                            
                            FROM TrainerAssignments TRAAss

                            INNER JOIN Trainers TRA
                            ON TRA.TrainerID = TRAAss.TrainerID

                            INNER JOIN Members MEM
                            ON MEM.MemberID = TRAAss.MemberID

                            INNER JOIN People PEOP
                            ON PEOP.PersonID = TRA.PersonID

                            INNER JOIN People PEOP2 
                            ON PEOP2.PersonID = MEM.PersonID

                            INNER JOIN Subscriptions SUB
                            ON SUB.MemberID = MEM.MemberID

                            INNER JOIN Memberships MEMShip 
                            ON MEMShip.MembershipID = SUB.MembershipID;


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllTrainerAssignments.Load(reader);
                }
            }

            return DT_AllTrainerAssignments;
        }
    }
}
