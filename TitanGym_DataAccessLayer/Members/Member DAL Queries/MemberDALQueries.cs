using System.Data;
using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Members
{
    public class MemberDALQueries
    {

        public static DataTable GetAllMembers()
        {
            DataTable DT_AllMembers = new DataTable();

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"
                                    SELECT
			 
					                             MEM.MemberID ,
					                             PEOP.PersonID,
					                             CONCAT (PEOP.FirstName , ' ' , PEOP.SecondName , ' ' , PEOP.ThirdName , ' ' , PEOP.LastName)  AS FullName ,
					                             MEMShip.MembershipName ,
					                             MEMShipStatus.NameMembershipStatus ,
					                             SUB.StartDate ,
					                             SUB.EndDate , 
					                             PEOP.EmailAddress , 
					                             PEOP.PhoneNumber  

			                        FROM Members MEM
			                        INNER JOIN Subscriptions SUB
			                        ON MEM.MemberID = SUB.MemberID 
			                        INNER JOIN People PEOP
			                        ON PEOP.PersonID = MEM.PersonID
			                        INNER JOIN Memberships MEMShip 
			                        ON MEMShip.MembershipID = SUB.MembershipID
			                        INNER JOIN MembershipStatuses MEMShipStatus
			                        ON MEMShipStatus.MembershipStatusID = MEM.MembershipStatusID

                               ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllMembers.Load(reader);

                }

            }

            return DT_AllMembers;
        }

        public static int GetTotalThePendingExpireMembershipMembers(int DayExpirememberShip)
        {

            int NumberPendingExpireMembers = 0;


            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"
                        
                  SELECT COUNT(*)
                  FROM Subscriptions
                  WHERE EndDate BETWEEN GETDATE()
                  AND DATEADD(DAY,@DayExpirememberShip,GETDATE());

                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@DayExpirememberShip", DayExpirememberShip);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int TotalExpire))
                        NumberPendingExpireMembers = TotalExpire;
                }


            }

            return NumberPendingExpireMembers;
        }

        public static bool FindTheMemberBy(

                int MemberID,
                ref string EmergencyContactName,
                ref string EmergencyContactPhoneNumber,
                ref DateTime RegistrationDate,
                ref byte MembershipStatusID,
                ref int PersonID

                )
        {


            bool FoundedMember = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                                                SELECT *
                                                FROM Members 
                                                WHERE MemberID = @MemberID



                       ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<int>("@MemberID", MemberID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            FoundedMember = true;
                            EmergencyContactName = reader.GetTheValueFrom<string>("EmergencyContactName");
                            EmergencyContactPhoneNumber = reader.GetTheValueFrom<string>("EmergencyContactPhoneNumber");
                            RegistrationDate = reader.GetTheValueFrom<DateTime>("RegistrationDate");
                            MembershipStatusID = reader.GetTheValueFrom<byte>("MembershipStatusID");
                            PersonID = reader.GetTheValueFrom<int>("PersonID");

                        }

                }
            }

            return FoundedMember;

        }

        public static bool IsMemberActiveAndExsitsBy(int personID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(HelperDAL.TitanGymConnectionString))
            {

                string Query = @"


                        SELECT TOP 1 FOUND = 1 
                        FROM Members
                        WHERE Members.PersonID = @PersonID AND MembershipStatusID = 1 


                  ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@PersonID", personID);
                    connection.Open();

                    object result = command.ExecuteScalar();

                    IsExists = result != null && Convert.ToBoolean(result);

                }
            }

            return IsExists;
        }

    }
}
