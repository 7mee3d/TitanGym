using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Trainers
{
    public class TrainerDALCommands
    {

        public static int InsertNewTrainer(

                       DateTime HireDate,
                       double Salary,
                       byte SpecializationID,
                       byte EmploymentStatusID,
                       int PersonID

            )
        {


            int TrainerID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"


                                        INSERT INTO Trainers
                                        (
                                                HireDate,
                                                Salary,
                                                SpecializationID,
                                                EmploymentStatusID,
                                                PersonID
                                        )
                                             VALUES
                                             (
                                                    @HireDate, 
                                                    @Salary, 
                                                    @SpecializationID,
                                                    @EmploymentStatusID,
                                                    @PersonID
                                                );
                                        
                                        SELECT SCOPE_IDENTITY();

                   ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<DateTime>("@HireDate", HireDate);
                    command.AddWithParameter<double>("@Salary", Salary);
                    command.AddWithParameter<byte>("@SpecializationID", SpecializationID);
                    command.AddWithParameter<byte>("@EmploymentStatusID", EmploymentStatusID);
                    command.AddWithParameter<int>("@PersonID", PersonID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int NewID))
                        TrainerID = NewID;


                }
            }

            return TrainerID;
        }

        public static bool UpdasteInformationTrainer(

                       int TrainerID,
                       DateTime HireDate,
                       double Salary,
                       byte SpecializationID,
                       byte EmploymentStatusID,
                       int PersonID

            )
        {


            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {


                string Query = @"


                                        UPDATE Trainers

                                             SET
                                                    HireDate = @HireDate, 
                                                    Salary = @Salary, 
                                                    SpecializationID = @SpecializationID,
                                                    EmploymentStatusID= @EmploymentStatusID,
                                                    PersonID = @PersonID
                                                
                                        
                                      WHERE TrainerID = @TrainerID

                   ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<DateTime>("@HireDate", HireDate);
                    command.AddWithParameter<double>("@Salary", Salary);
                    command.AddWithParameter<byte>("@SpecializationID", SpecializationID);
                    command.AddWithParameter<byte>("@EmploymentStatusID", EmploymentStatusID);
                    command.AddWithParameter<int>("@PersonID", PersonID);
                    command.AddWithParameter<int>("@TrainerID", TrainerID);

                    connection.Open();

                    IsUpdated = command.ExecuteNonQuery() > 0;


                }
            }

            return IsUpdated;
        }
    }
}
