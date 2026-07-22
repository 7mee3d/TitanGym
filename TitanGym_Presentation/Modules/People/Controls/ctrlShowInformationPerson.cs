using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;
using TitanGym_Presentation.Core.Utility;

namespace TitanGym_Presentation.Modules.People.Controls
{
    public partial class ctrlShowInformationPerson : UserControl
    {
        public ctrlShowInformationPerson()
        {
            InitializeComponent();
        }
        private PeopleBL _InformationPerson;

        public void LoadInformationPerson(int personID)
        {
            _InformationPerson = PeopleBL.FindThePersonBy(personID);

            if (_InformationPerson is null)
                return;


            lblPersonID.Text = _InformationPerson.PersonID.ToString();
            lblFullName.Text = _InformationPerson.FullName;
            lblResidentialAddress.Text = _InformationPerson.ResidentialAddress;
            lblEmailAddress.Text = _InformationPerson.EmailAddress;
            lblPhoneNumber.Text = _InformationPerson.PhoneNumber;
            lblGender.Text = _InformationPerson.Gender == 'M' ? "Male" : "Female";

            if (!string.IsNullOrWhiteSpace(_InformationPerson.ImagePath))
                GPictureBoxImagePerson.ImageLocation = Utility.DirectoryPath + _InformationPerson.ImagePath;
        }
    }
}
