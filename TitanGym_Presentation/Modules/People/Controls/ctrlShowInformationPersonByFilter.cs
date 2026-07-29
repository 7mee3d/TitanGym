using System;
using System.Windows.Forms;
using TitanGym_Presentation.Modules.People.Forms;

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

        public int PersonID { get { return _PersonID; } }

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

        private void GGButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            var ucAddEditPerson = new UCAddEditPerson();

            ucAddEditPerson.FinihedAddEditPerson += result =>
            {
                if (result.IsAddedOrEdited)
                {
                    int NewPersonID = result.NewPersonID;
                    GTextBoxPersonID.Text = NewPersonID.ToString();
                    _PersonID = NewPersonID;
                    ctrlShowInformationPerson1.LoadInformationPerson(NewPersonID);
                }
            };

            AppNavigator.Show(ucAddEditPerson);
        }
    }
}
