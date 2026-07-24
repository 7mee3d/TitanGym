using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Memberships
{
    public class MembershipsDALCommands
    {

        public static int InsertNewMembershipPlan(
               string MembershipName,
               byte Duration,
               double MonthlyPrice,
               string Description,
               byte AvailabilityStatusID
            )
        {


            int MembershipID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                                    INSERT INTO Memberships (
                                                 MembershipName , 
                                                 Duration, 
                                                 MonthlyPrice,
                                                 Description	,
                                                 AvailabilityStatusID
                                    )
                                    
                                    VALUES (
                                    
                                    			@MembershipName ,
                                    			@Duration,
                                    			@MonthlyPrice,
                                    			@Description	, 
                                    			@AvailabilityStatusID
                                    
                                    );
                                    
                                    SELECT SCOPE_IDENTITY();


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<string>("@MembershipName", MembershipName);
                    command.AddWithParameter<byte>("@Duration", Duration);
                    command.AddWithParameter<double>("@MonthlyPrice", MonthlyPrice);
                    if (!string.IsNullOrWhiteSpace(Description.Trim()))
                        command.AddWithParameter<string>("@Description", Description);
                    else
                        command.AddWithParameter<object>("@Description", DBNull.Value);

                    command.AddWithParameter<byte>("@AvailabilityStatusID", AvailabilityStatusID);


                    connection.Open();

                    try
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                            MembershipID = ID;
                    }
                    catch
                    {
                        return MembershipID;
                    }

                }

            }

            return MembershipID;
        }


    }
}
