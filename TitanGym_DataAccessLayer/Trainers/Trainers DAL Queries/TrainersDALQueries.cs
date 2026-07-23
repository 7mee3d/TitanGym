using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Trainers
{
    public class TrainersDALQueries
    {

        public static DataTable GetAllTrainers()
        {

            DataTable DT_AllTrainers = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"
                                  SELECT
                                               TRA.TrainerID,
                                               TRA.PersonID,
                                               CONCAT(
                                                   PEOP.FirstName, ' ',
                                                   PEOP.SecondName, ' ',
                                                   PEOP.ThirdName, ' ',
                                                   PEOP.LastName
                                               ) AS FullName,
                                               SPEC.SpecializationName,
                                               EmpStatus.NameEmploymentStatus,
                                               TRA.HireDate,
                                               SPEC.Salary,
                                               COUNT(TA.MemberID) AS MemberAssignmentsWithTrainer

                                    FROM Trainers TRA
                                    
                                    INNER JOIN People PEOP
                                        ON PEOP.PersonID = TRA.PersonID
                                    
                                    INNER JOIN Specializations SPEC
                                        ON SPEC.SpecializationID = TRA.SpecializationID
                                    
                                    INNER JOIN EmploymentStatuses EmpStatus
                                        ON EmpStatus.EmploymentStatusID = TRA.EmploymentStatusID
                                    
                                    LEFT JOIN TrainerAssignments TA
                                        ON TA.TrainerID = TRA.TrainerID

                            GROUP BY
                                TRA.TrainerID,
                                TRA.PersonID,
                                PEOP.FirstName,
                                PEOP.SecondName,
                                PEOP.ThirdName,
                                PEOP.LastName,
                                SPEC.SpecializationName,
                                EmpStatus.NameEmploymentStatus,
                                SPEC.Salary,
                                TRA.HireDate;
                           
";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllTrainers.Load(reader);
                }
            }

            return DT_AllTrainers;
        }
    }
}
