using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanGym_DataAccessLayer.Trainers;

namespace TitanGym_BusinessLayer.TrainersBL
{
    public class TrainerBL
    {


        public static DataTable GetAllTrainers()
            => TrainersDALQueries.GetAllTrainers();
    }
}
