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
        public enum EnLoginStatus
        {
            _LOGIN_FAILD = 1,
            _LOGIN_SUCCESS = 2,
            _LOGIN_USER_NOT_ACTIVE = 3,
            _LOGIN_USER_NOT_FOUNDED = 4

        };

        public class LoginResult
        {
            public int UserID { get; set; }
            public bool IsActiveUser { get; set; }
            public bool IsAuthenticated { get; set; }
            public string Message { get; set; }
            public EnLoginStatus Status { get; set; }

            public LoginResult(int userID, bool isActiveUser, bool isAuthenticated, string message, EnLoginStatus status)
            {
                this.UserID = userID;
                this.IsActiveUser = isActiveUser;
                this.IsAuthenticated = isAuthenticated;
                this.Message = message;
                this.Status = status;
            }
        }

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

        public static UserBL FindTheUserBy(string Username)
        {
            string password = "";
            DateTime creationDateUser = DateTime.Now;
            byte accountStatusID = 0, roleID = 0;
            int personID = 0, UserID = 0;

            bool IsFound = UsersDALQueries.FindTheUserBy(Username, ref UserID, ref password, ref creationDateUser, ref accountStatusID, ref personID, ref roleID);

            if (IsFound)
                return new UserBL(UserID, Username, password, creationDateUser, accountStatusID, personID, roleID);
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

        public static LoginResult LoginTitanGYM(string username, string password)
        {
            const string defaultError = "Invalid username or password";


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new LoginResult(
                    userID: -1,
                    isActiveUser: false,
                    isAuthenticated: false,
                    message: "Please enter a valid username and password",
                    status: EnLoginStatus._LOGIN_FAILD);
            }


            if (!UsersDALQueries.IsUserExistsBy(username))
            {
                return new LoginResult(
                    userID: -1,
                    isActiveUser: false,
                    isAuthenticated: false,
                    message: "This user does not exist in Titan Gym. Please enter a valid username.",
                    status: EnLoginStatus._LOGIN_USER_NOT_FOUNDED);
            }

            if (!UsersDALQueries.IsUserExistsBy(username, password))
            {
                return new LoginResult(
                    userID: -1,
                    isActiveUser: false,
                    isAuthenticated: false,
                    message: defaultError,
                    status: EnLoginStatus._LOGIN_FAILD);
            }

            var user = UsersBL.UserBL.FindTheUserBy(username);

            if (user.AccountStatusID != 1)
            {
                return new LoginResult(
                    userID: user.UserID,
                    isActiveUser: false,
                    isAuthenticated: false,
                    message: "Your account is not active. Please contact administration.",
                    status: EnLoginStatus._LOGIN_USER_NOT_ACTIVE);
            }

            // Successful login
            return new LoginResult(
                userID: user.UserID,
                isActiveUser: true,
                isAuthenticated: true,
                message: "Thank you for using Titan Gym — enjoy your session!",
                status: EnLoginStatus._LOGIN_SUCCESS);
        }


    }
}
