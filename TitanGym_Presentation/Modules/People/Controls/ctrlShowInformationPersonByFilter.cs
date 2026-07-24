using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;

namespace TitanGym_Presentation.Modules.People.Controls
{
    public partial class ctrlShowInformationPersonByFilter : UserControl
    {
        public ctrlShowInformationPersonByFilter()
        {
            InitializeComponent();
        }

        private int _PersonID = -1;
        public event EventHandler<int> EHFinishedSearchPerson;

        private bool _EnableControl = false;

        public bool EnableControls
        {
            private get
            {
                return _EnableControl;
            }

            set
            {
                _EnableControl = value;
                GTextBoxPersonID.Enabled = _EnableControl;
                GGButtonSearchPerson.Enabled = _EnableControl;
            }
        }

        private void GGButtonSearchPerson_Click(object sender, EventArgs e)
        {
            int.TryParse(GTextBoxPersonID.Text.Trim(), out int ID);

            _PersonID = ID;
            if (ctrlShowInformationPerson1.LoadInformationPerson(_PersonID))
                EHFinishedSearchPerson?.Invoke(this, _PersonID);


            FocusTheTextBoxPersonID();
        }

        public void LoadInformationPerson(int PersonID)
        {

            if (ctrlShowInformationPerson1.LoadInformationPerson(PersonID))
                EHFinishedSearchPerson?.Invoke(this, PersonID);


            _PersonID = PersonID;
            GTextBoxPersonID.Text = _PersonID.ToString();
        }

        public void FocusTheTextBoxPersonID()
        {
            GTextBoxPersonID.Focus();
            GTextBoxPersonID.SelectAll();
        }
    }
}
