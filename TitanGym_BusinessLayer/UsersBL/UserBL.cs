using System;
using System.Data;
using TitanGym_DataAccessLayer.Users;

namespace TitanGym_BusinessLayer.UsersBL
{
    public class UserBL
    {

        public enum EnUsersMode
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2
        };


        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDateUser { get; set; }
        public byte AccountStatusID { get; set; }
        public int PersonID { get; set; }
        public byte RoleID { get; set; }
        public EnUsersMode ModeUser { get; private set; }

        public UserBL(

            int userID,
            string username,
            string password,
            DateTime creationDateUser,
            byte accountStatusID,
            int personID,
            byte roleID

            )
        {
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.CreationDateUser = creationDateUser;
            this.AccountStatusID = accountStatusID;
            this.PersonID = personID;
            this.RoleID = roleID;
            this.ModeUser = EnUsersMode._kUPDATE_INFORMATION_USER;
        }

        public UserBL()
        {
            this.UserID = default;
            this.Username = default;
            this.Password = default;
            this.CreationDateUser = default;
            this.AccountStatusID = default;
            this.PersonID = default;
            this.RoleID = default;
            this.ModeUser = EnUsersMode._kADD_NEW_USER;
        }


        public static DataTable GetAllUsers()
            => UsersDALQueries.GetAllUsers();


        private bool _AddNewUser()
        {
            this.UserID = UsersDALCommands.InsertNewUser(
                Username,
                Password,
                CreationDateUser,
                AccountStatusID,
                PersonID,
                RoleID);

            return this.UserID != -1;

        }

        public bool SaveModeUser()
        {

            switch (this.ModeUser)
            {
                case EnUsersMode._kADD_NEW_USER:

                    if (_AddNewUser())
                    {
                        this.ModeUser = EnUsersMode._kUPDATE_INFORMATION_USER;
                        return true;
                    }

                    return false;

                case EnUsersMode._kUPDATE_INFORMATION_USER:
                    return false;

                default: return false;
            }
        }

        public static bool IsExistsUserBy(string Username)
            => UsersDALQueries.IsUserExistsBy(Username);
    }
}
