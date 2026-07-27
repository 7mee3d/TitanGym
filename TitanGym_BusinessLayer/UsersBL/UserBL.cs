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

        private PeopleBL.PeopleBL _InformationPerson;

        public PeopleBL.PeopleBL InformationPerson
        {

            get
            {
                if (_InformationPerson is null)
                    _InformationPerson = PeopleBL.PeopleBL.FindThePersonBy(this.PersonID);

                return _InformationPerson;
            }

        }

        private RolesBL.RoleBL _InformationRole;


        public RolesBL.RoleBL InformationRole
        {

            get
            {
                if (_InformationRole is null)
                    _InformationRole = RolesBL.RoleBL.FindTheRoleBy(this.RoleID);

                return _InformationRole;
            }
        }

        public Account_StatusesBL.AccountStatusBL _InformatioNAccountStatus;

        public Account_StatusesBL.AccountStatusBL InformationAccountStatus
        {

            get
            {
                if (_InformatioNAccountStatus is null)
                    _InformatioNAccountStatus = Account_StatusesBL.AccountStatusBL.FindTheAccountStatusBy(this.AccountStatusID);

                return _InformatioNAccountStatus;
            }
        }


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

        public static UserBL FindTheUserBy(int UserID)
        {
            string username = "", password = "";
            DateTime creationDateUser = DateTime.Now;
            byte accountStatusID = 0, roleID = 0;
            int personID = 0;

            bool IsFound = UsersDALQueries.FindTheUserBy(UserID, ref username, ref password, ref creationDateUser, ref accountStatusID, ref personID, ref roleID);

            if (IsFound)
                return new UserBL(UserID, username, password, creationDateUser, accountStatusID, personID, roleID);
            else return null;
        }

        public static DataTable GetAllUsers()
            => UsersDALQueries.GetAllUsers();


        private bool _AddNewUser()
        {
            this.UserID = UsersDALCommands.InsertNewUser(
                this.Username,
                this.Password,
                this.CreationDateUser,
                this.AccountStatusID,
                this.PersonID,
                this.RoleID);

            return this.UserID != -1;

        }

        private bool _UpdateInformationUser()
        {
            return UsersDALCommands.UpdateInformationUser(
                 this.UserID,
                 this.Username,
                 this.Password,
                 this.CreationDateUser,
                 this.AccountStatusID,
                 this.PersonID,
                 this.RoleID);


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
                    return _UpdateInformationUser();

                default: return false;
            }
        }

        public static bool IsExistsUserBy(string Username)
            => UsersDALQueries.IsUserExistsBy(Username);
    }
}
