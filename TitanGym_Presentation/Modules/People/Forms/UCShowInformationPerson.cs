using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.People.Forms
{
    public partial class UCShowInformationPerson : UserControl
    {
        private readonly int _PersonID = -1;
        public event Action<bool> FinishedShowInfoPerson;

        public UCShowInformationPerson(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void UCShowInformationPerson_Load(object sender, EventArgs e)
        {
            ctrlShowInformationPerson1.LoadInformationPerson(_PersonID);
            FinishedShowInfoPerson?.Invoke(false);
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void ctrlShowInformationPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
