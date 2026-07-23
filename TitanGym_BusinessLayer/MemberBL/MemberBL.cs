

using System;
using System.Data;
using TitanGym_BusinessLayer.PeopleBL;
using TitanGym_DataAccessLayer.Members;

namespace TitanGym_BusinessLayer.MemberBL
{
    public class MemberBL
    {
        //MemberID	EmergencyContactPhoneNumber	EmergencyContactName	RegistrationDate	MembershipStatusID	PersonID

        public enum _EnModeMember
        {
            _kADD_NEW_MEMBER = 1,
            _kUPDATE_INFORMATION_MEMBER = 2
        };

        public enum enMembershipStatus
        {
            _kACTIVE = 1,
            _kINACTIVE = 2,
            _kSUSPENDED = 3,
            _kEXPIRED = 4,
            _kPENDING = 5
        }

        public int MemberID { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public enMembershipStatus MembershipStatusID { get; set; }
        public int PersonID { get; set; }
        public _EnModeMember _ModeMember { get; private set; }

        private PeopleBL.PeopleBL _InformationPerson;

        public PeopleBL.PeopleBL PersonInformation
        {
            get
            {
                if (_InformationPerson == null)
                    _InformationPerson = PeopleBL.PeopleBL.FindThePersonBy(PersonID);

                return _InformationPerson;
            }
        }


        public MemberBL(

            int memberID,
            string emergencyContactName,
            string emergencyContactPhoneNumber,
            DateTime registrationDate,
            enMembershipStatus membershipStatusID,
            int personID

            )
        {
            this.MemberID = memberID;
            this.EmergencyContactName = emergencyContactName;
            this.EmergencyContactPhoneNumber = emergencyContactPhoneNumber;
            this.RegistrationDate = registrationDate;
            this.MembershipStatusID = membershipStatusID;
            this.PersonID = personID;

            _ModeMember = _EnModeMember._kUPDATE_INFORMATION_MEMBER;
        }

        public MemberBL()
        {
            this.MemberID = default;
            this.EmergencyContactName = default;
            this.EmergencyContactPhoneNumber = default;
            this.RegistrationDate = default;
            this.MembershipStatusID = default;
            this.PersonID = default;

            _ModeMember = _EnModeMember._kADD_NEW_MEMBER;
        }

        public static MemberBL FindTheMemberBy(int MemberID)
        {
            string emergencyContactName = "", emergencyContactPhoneNumber = "";
            DateTime registrationDate = DateTime.Now;
            byte membershipStatusID = 1;
            int personID = 0;

            bool FoundedMember =
                MemberDALQueries.FindTheMemberBy(
                    MemberID,
                    ref emergencyContactName,
                    ref emergencyContactPhoneNumber,
                    ref registrationDate,
                    ref membershipStatusID,
                    ref personID
                    );

            if (FoundedMember)
                return new MemberBL(
                    MemberID,
                    emergencyContactName,
                    emergencyContactPhoneNumber,
                    registrationDate,
                    (enMembershipStatus)membershipStatusID,
                    personID)
                    ;
            else return null;
        }

        private bool _AddNewMember()
        {
            this.MemberID = MemberDALCommands.InsertNewMember(EmergencyContactName, EmergencyContactPhoneNumber, RegistrationDate, (byte)MembershipStatusID, PersonID);
            return this.MemberID != -1;

        }

        public static DataTable GetAllMembers()
            => MemberDALQueries.GetAllMembers();

        public static int GetTheMembersPendingExpireBy(int DayPendingExpire)
            => MemberDALQueries.GetTotalThePendingExpireMembershipMembers(DayPendingExpire);

        private bool _UpdateInformationMember()
            => MemberDALCommands.UpdateInformatonMember(
                MemberID,
                EmergencyContactName,
                EmergencyContactPhoneNumber,
                RegistrationDate,
                (byte)MembershipStatusID,
                PersonID) != -1;


        public bool SaveModeMember()
        {

            switch (_ModeMember)
            {
                case _EnModeMember._kADD_NEW_MEMBER:
                    _ModeMember = _EnModeMember._kUPDATE_INFORMATION_MEMBER;
                    return _AddNewMember();

                case _EnModeMember._kUPDATE_INFORMATION_MEMBER:
                    return _UpdateInformationMember();

                default: return false;
            }

        }

        public bool IsMemberActiveAndExistsBy()
            => MemberDALQueries.IsMemberActiveAndExsitsBy(this.PersonID);
    }
}
