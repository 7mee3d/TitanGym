using System;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Trainers.Forms
{
    public partial class UCShowInformationTrainer : UserControl
    {
        private int _TrainerID = -1;
        public event Action<bool> FinishedShowInfoTrainer;

        public UCShowInformationTrainer(int trainerID)
        {
            InitializeComponent();

            _TrainerID = trainerID;
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCShowInformationTrainer_Load(object sender, EventArgs e)
        {
            ctrlShowInformationTrainer1.LoadInformationTrainer(_TrainerID);
            FinishedShowInfoTrainer?.Invoke(false);
        }


    }
}
