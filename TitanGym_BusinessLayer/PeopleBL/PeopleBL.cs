using System;
using System.Data;
using TitanGym_DataAccessLayer.People;
using TitanGym_DataAccessLayer.People.People_DAL_Commands;

namespace TitanGym_BusinessLayer.PeopleBL
{
    public class PeopleBL
    {

        public enum _EnModePeople : byte
        {
            _kADD_NEW_PERSON = 1,
            _kUPDATE_INFORMATION_PERSON = 2

        }

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public _EnModePeople EnModePerson { get; set; }


        public PeopleBL(

            int personID,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            char gender,
            string phoneNumber,
            string emailAddress,
            string residentialAddress,
            DateTime dateOfBirth,
            string imagePath

            )
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.ResidentialAddress = residentialAddress;
            this.DateOfBirth = dateOfBirth;
            this.ImagePath = imagePath;
            EnModePerson = _EnModePeople._kUPDATE_INFORMATION_PERSON;

        }

        public PeopleBL()
        {

            this.PersonID = default;
            this.FirstName = default;
            this.SecondName = default;
            this.ThirdName = default;
            this.LastName = default;
            this.Gender = default;
            this.PhoneNumber = default;
            this.EmailAddress = default;
            this.ResidentialAddress = default;
            this.DateOfBirth = default;
            this.ImagePath = default;
            EnModePerson = _EnModePeople._kADD_NEW_PERSON;
        }

        public static PeopleBL FindThePersonBy(int personID)
        {

            string firstName = "", secondName = "", thirdName = "", lastName = "", phoneNumber = "", emailAddress = "", residentialAddress = "", imagePath = "";
            char gender = '\0';
            DateTime dateOfBirth = DateTime.Now;

            bool IsFounded = PeopleDALQueries.FindThePersonBy(

                personID,
                ref firstName,
                ref secondName,
                ref thirdName,
                ref lastName,
                ref gender,
                ref phoneNumber,
                ref emailAddress,
                ref residentialAddress,
                ref dateOfBirth,
                ref imagePath

                );


            if (IsFounded)
                return new PeopleBL(personID, firstName, secondName, thirdName, lastName, gender, phoneNumber, emailAddress, residentialAddress, dateOfBirth, imagePath);
            else return null;

        }

        public static DataTable GetAllPeople() => PeopleDALQueries.GetAllPeople();

        private bool _AddNewPerson()
        {
            this.PersonID = PeopleDALCommands.InsertNewPerson(

                this.FirstName,
                this.SecondName,
                this.ThirdName,
                this.LastName,
                this.Gender,
                this.PhoneNumber,
                this.EmailAddress,
                this.ResidentialAddress,
                this.DateOfBirth,
                this.ImagePath

                );

            return this.PersonID != -1;
        }

        private bool _UpdateInformationPerson()
        {
            return PeopleDALCommands.UpdateInformationPerson(

               this.PersonID,
               this.FirstName,
               this.SecondName,
               this.ThirdName,
               this.LastName,
               this.Gender,
               this.PhoneNumber,
               this.EmailAddress,
               this.ResidentialAddress,
               this.DateOfBirth,
               this.ImagePath

               );
        }

        public bool SaveModePerson()
        {

            switch (this.EnModePerson)
            {
                case _EnModePeople._kADD_NEW_PERSON:
                    EnModePerson = _EnModePeople._kUPDATE_INFORMATION_PERSON;
                    return _AddNewPerson();

                case _EnModePeople._kUPDATE_INFORMATION_PERSON:
                    return _UpdateInformationPerson();

                default: return false;
            }
        }

        public static bool DeletePerson(int personID)
            => PeopleDALQueries.DeletePerson(personID);
    }
}
