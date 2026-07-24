using System;
using System.Data;
using TitanGym_DataAccessLayer.Trainers;

namespace TitanGym_BusinessLayer.TrainersBL
{
    public class TrainerBL
    {
        public enum _EnModeTrainer
        {
            _kADD_NEW_TRAINER = 1,
            _kUPDATE_INFORMATION_TRAINER = 2
        };


        public int TrainerID { get; set; }
        public int PersonID { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public byte SpecializationID { get; set; }
        public byte EmploymentStatusID { get; set; }

        public _EnModeTrainer _Mode { get; private set; }

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

        public TrainerBL(

            int trainerID,
            int personID,
            DateTime hireDate,
            double salary,
            byte specializationID,
            byte employmentStatusID

            )
        {
            this.TrainerID = trainerID;
            this.PersonID = personID;
            this.HireDate = hireDate;
            this.Salary = salary;
            this.SpecializationID = specializationID;
            this.EmploymentStatusID = employmentStatusID;
            _Mode = _EnModeTrainer._kUPDATE_INFORMATION_TRAINER;
        }

        public TrainerBL()
        {
            this.TrainerID = default;
            this.PersonID = default;
            this.HireDate = default;
            this.Salary = default;
            this.SpecializationID = default;
            this.EmploymentStatusID = default;
            _Mode = _EnModeTrainer._kADD_NEW_TRAINER;
        }

        public static TrainerBL FindTrainerBy(int trainerID)
        {

            int personID = 0;

            DateTime hireDate = DateTime.Now;
            double salary = 0.0d;
            byte specializationID = 0, employmentStatusID = 0;


            bool IsFounded = TrainersDALQueries.FindTheTrainerBy(
                trainerID,
                ref hireDate,
                ref specializationID,
                ref employmentStatusID,
                ref personID,
                ref salary
                );

            if (IsFounded)
                return new TrainerBL(

                    trainerID,
                    personID,
                    hireDate,
                    salary,
                    specializationID,
                    employmentStatusID

                    );
            else return null;
        }

        private bool _AddNewTrainer()
        {
            this.TrainerID = TrainerDALCommands.InsertNewTrainer(
                this.HireDate,
                this.Salary,
                this.SpecializationID,
                this.EmploymentStatusID,
                this.PersonID
                );

            return this.TrainerID != -1;
        }

        private bool _UpdateInformationTrainer()
        {
            return TrainerDALCommands.UpdasteInformationTrainer(
                TrainerID,
                HireDate,
                Salary,
                SpecializationID,
                EmploymentStatusID,
                PersonID
                );
        }

        public bool SaveModeTrainer()
        {

            switch (_Mode)
            {

                case _EnModeTrainer._kADD_NEW_TRAINER:
                    _Mode = _EnModeTrainer._kUPDATE_INFORMATION_TRAINER;
                    return _AddNewTrainer();

                case _EnModeTrainer._kUPDATE_INFORMATION_TRAINER:
                    return _UpdateInformationTrainer();

                default: return false;

            }
        }

        public static bool DeleteTrainer(int trainerID)
            => TrainerDALCommands.DeleteTrainer(trainerID);

        public static DataTable GetAllTrainers()
            => TrainersDALQueries.GetAllTrainers();

        public static bool IsExistsTrainerBy(int personID)
            => TrainersDALQueries.IsExistsTrainerBy(personID);
    }
}
