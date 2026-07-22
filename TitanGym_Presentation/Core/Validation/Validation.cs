using System;

namespace TitanGym_Presentation.Core.Validation
{
    public static class Validation
    {

        public static bool ValidationEmail(string Email)
        {
            try
            {

                return new System.Net.Mail.MailAddress(Email).Address == Email;

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
