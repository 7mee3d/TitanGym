using System;
using System.Data;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Payments
{
    public class PaymentsDALQueries
    {

        public static DataTable GetAllPayemnts()
        {

            DataTable DT_AllInformationPayments = new DataTable();

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                            SELECT
                            
                                    PAY.PaymentID ,
                                    PAY.SubscriptionID ,
                                    PAY.PaymentDate ,
                                    PAY.Amount , 
                                    PAY.Note , 
                                    PayMethod.NamePaymentMethod ,
                                    PayStatus.NamePaymentStatus
                            
                            FROM Payments PAY
                            INNER JOIN PaymentMethods PayMethod 
                            ON PayMethod.PaymentMethodID =  PAY.PaymentMethodID
                            INNER JOIN PaymentStatuses PayStatus 
                            ON PayStatus.PaymentStatusID = PAY.PaymentStatusID


                 ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllInformationPayments.Load(reader);

                }
            }

            return DT_AllInformationPayments;
        }

        public static int FindThePaymentBy(

            int SubscriptionID,
            ref int PaymentID,
            ref DateTime PaymentDate,
            ref double Amount,
            ref string Note,
            ref byte NamePaymentMethod,
            ref byte NamePaymentStatus


            )
        {

            bool Founded = false;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"

                        SELECT

                                   PAY.PaymentID ,
                                   PAY.SubscriptionID ,
                                   PAY.PaymentDate ,
                                   PAY.Amount , 
                                   PAY.Note , 
                                   PAY.PaymentMethodID ,
                                   PAY.PaymentStatusID
                                   
                                   FROM Payments PAY


                        WHERE PAY.SubscriptionID = @SubscriptionID


                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.AddWithParameter<int>("@SubscriptionID", SubscriptionID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            Founded = true;


                            PaymentID = reader.GetTheValueFrom<int>("PaymentID");
                            PaymentDate = reader.GetTheValueFrom<DateTime>("PaymentDate");
                            Amount = reader.GetTheValueFrom<double>("Amount");
                            Note = reader.GetTheValueFrom<string>("Note");
                            NamePaymentMethod = reader.GetTheValueFrom<byte>("PaymentMethodID");
                            NamePaymentStatus = reader.GetTheValueFrom<byte>("PaymentStatusID");

                        }
                }


            }

            return Founded;
        }

    }
}
