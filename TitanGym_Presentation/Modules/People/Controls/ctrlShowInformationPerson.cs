using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;
using TitanGym_Presentation.Core.Utility;
using TitanGym_Presentation.Properties;

namespace TitanGym_Presentation.Modules.People.Controls
{
    public partial class ctrlShowInformationPerson : UserControl
    {
        public ctrlShowInformationPerson()
        {
            InitializeComponent();
        }

        private PeopleBL _InformationPerson;

        public void _DefaultValues()
        {
            lblPersonID.Text = "[???]";
            lblFullName.Text = "[???]";
            lblResidentialAddress.Text = "[???]";
            lblEmailAddress.Text = "[???]";
            lblPhoneNumber.Text = "[???]";
            lblGender.Text = "[???]";
            GPictureBoxImagePerson.Image = Resources.account_circle_Icon_TitanGym_50;
        }

        public bool LoadInformationPerson(int personID)
        {
            _InformationPerson = PeopleBL.FindThePersonBy(personID);

            if (_InformationPerson is null)
            {
                _DefaultValues();
                MessageBox.Show("This person not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            lblPersonID.Text = _InformationPerson.PersonID.ToString();
            lblFullName.Text = _InformationPerson.FullName;
            lblResidentialAddress.Text = _InformationPerson.ResidentialAddress;
            lblEmailAddress.Text = _InformationPerson.EmailAddress;
            lblPhoneNumber.Text = _InformationPerson.PhoneNumber;
            lblGender.Text = _InformationPerson.Gender == 'M' ? "Male" : "Female";
            GPictureBoxImagePerson.Image = Resources.account_circle_Icon_TitanGym_50;

            if (!string.IsNullOrWhiteSpace(_InformationPerson.ImagePath))
                GPictureBoxImagePerson.ImageLocation = Utility.DirectoryPath + _InformationPerson.ImagePath;

            return true;
        }
    }
}
