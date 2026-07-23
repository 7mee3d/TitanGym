using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Members
{
    public class MemberDALCommands
    {

        public static int InsertNewMember(

                 string EmergencyContactName,
                 string EmergencyContactPhoneNumber,
                 DateTime RegistrationDate,
                 byte MembershipStatusID,
                 int PersonID
            )
        {

            int MemberID = -1;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                        INSERT INTO Members
                                (
                                        EmergencyContactPhoneNumber,
                                        EmergencyContactName,
                                        RegistrationDate,
                                        MembershipStatusID,
                                        PersonID
                                )

                         VALUES
                           
                                (
                                    @EmergencyContactPhoneNumber,
                                    @EmergencyContactName,
                                    @RegistrationDate, 
                                    @MembershipStatusID,
                                    @PersonID

                                );
                            
                            SELECT SCOPE_IDENTITY();

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<string>("@EmergencyContactPhoneNumber", EmergencyContactPhoneNumber);
                    command.AddWithParameter<string>("@EmergencyContactName", EmergencyContactName);
                    command.AddWithParameter<DateTime>("@RegistrationDate", RegistrationDate);
                    command.AddWithParameter<byte>("@MembershipStatusID", MembershipStatusID);
                    command.AddWithParameter<int>("@PersonID", PersonID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int MemID))
                        MemberID = MemID;

                }

            }

            return MemberID;
        }

    }
}
