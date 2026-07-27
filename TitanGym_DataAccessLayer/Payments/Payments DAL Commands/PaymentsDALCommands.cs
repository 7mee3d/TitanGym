using System;
using System.Data.SqlClient;
using TitanGym_DataAccessLayer.Helper;

namespace TitanGym_DataAccessLayer.Payments
{
    public class PaymentsDALCommands
    {

        public static int InsertNewPayment(

            int subscriptionID,
            byte paymentMethodID,
            byte paymentStatusID,
            DateTime paymentDate,
            double amount,
            string note


            )
        {

            int PaymentID = -1;

            using (SqlConnection connection = new SqlConnection(Helper.HelperDAL.TitanGymConnectionString))
            {

                string Query = @"
                                    INSERT INTO Payments (
                                                                Amount, 
                                                                PaymentDate,
                                                                Note,
                                                                PaymentMethodID,
                                                                PaymentStatusID,
                                                                SubscriptionID
                                                        ) 
                                    VALUES (

                                                    @Amount,
                                                    @PaymentDate,
                                                    @Note, 
                                                    @PaymentMethodID,
                                                    @PaymentStatusID, 
                                                    @SubscriptionID
                                        );

                                    SELECT SCOPE_IDENTITY();

                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.AddWithParameter<int>("@SubscriptionID", subscriptionID);
                    command.AddWithParameter<byte>("@PaymentMethodID", paymentMethodID);
                    command.AddWithParameter<byte>("@PaymentStatusID", paymentStatusID);
                    command.AddWithParameter<DateTime>("@PaymentDate", DateTime.Now);
                    if (!String.IsNullOrWhiteSpace(note))
                        command.AddWithParameter<string>("@Note", note);
                    else
                        command.AddWithParameter<object>("@Note", DBNull.Value);

                    command.AddWithParameter<double>("@Amount", amount);


                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        PaymentID = ID;
                }

            }

            return PaymentID;
        }
    }
}
