using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;
using TitanGym_Presentation.Core.Helpers;
using TitanGym_Presentation.Core.Utility;

namespace TitanGym_Presentation.Modules.People.Forms
{
    public partial class UCAddEditPerson : UserControl
    {

        private PeopleBL _InformationPerson;

        public event Action<bool> FinihedAddEditPerson;

        private enum _EnModePerson : byte
        {
            _kADD_NEW_PERSON = 1,
            _kUPDATE_INFORMATION_PERSON = 2
        }

        private _EnModePerson _ModePerson = _EnModePerson._kADD_NEW_PERSON;

        public UCAddEditPerson()
        {
            InitializeComponent();
        }


        private void _PrepareInformationPerson()
        {
            _InformationPerson.FirstName = GTextBoxFirstName.Text.Trim();
            _InformationPerson.SecondName = GTextBoxSecondName.Text.Trim();
            _InformationPerson.ThirdName = GTextBoxThirdName.Text.Trim();
            _InformationPerson.LastName = GTextBoxThirdName.Text.Trim();

            _InformationPerson.ResidentialAddress = GTextBoxResidentialAddress.Text.Trim();

            if (GGButtonMale.Checked)
                _InformationPerson.Gender = 'M';
            else _InformationPerson.Gender = 'F';

            _InformationPerson.EmailAddress = GTextBoxEmailAddress.Text.Trim();
            _InformationPerson.PhoneNumber = GTextBoxPhoneNumber.Text.Trim();
            _InformationPerson.DateOfBirth = GDateTimePickerPerson.Value;

        }

        private void _AddNewPerson()
        {
            _PrepareInformationPerson();

            if (!string.IsNullOrWhiteSpace(GPictureBoxImagePerson.ImageLocation))
                _InformationPerson.ImagePath = Utility.SaveTheImage(GPictureBoxImagePerson.ImageLocation);

            if (_InformationPerson.SaveModePerson())
            {
                if (_ModePerson == _EnModePerson._kADD_NEW_PERSON) MessageBox.Show("The Person Added Sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Person Updated Sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FinihedAddEditPerson?.Invoke(true);
            }
            else MessageBox.Show("The Person Added Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GGButtonAddNewPerson.Text = "Update Person";
            _ModePerson = _EnModePerson._kUPDATE_INFORMATION_PERSON;
            lblTitlePerson.Text = "Update New Person";
        }

        private void _DefaultValues()
        {
            if (_ModePerson == _EnModePerson._kADD_NEW_PERSON)
            {
                GGButtonAddNewPerson.Text = "Add Person";
                _InformationPerson = new PeopleBL();
                lblTitlePerson.Text = "Add New Person";
                return;
            }

        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCAddEditPerson_Load(object sender, EventArgs e)
        {
            _DefaultValues();


        }

        private void GGButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void GGButtonUpload_Click(object sender, EventArgs e)
        {
            openFileDialogSelectImagePerson.RestoreDirectory = true;
            openFileDialogSelectImagePerson.Filter = "PNG IMAGE|*.png|JPGE IAMGE|*jpge";
            openFileDialogSelectImagePerson.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialogSelectImagePerson.ShowDialog() == DialogResult.OK)
            {
                GPictureBoxImagePerson.ImageLocation = openFileDialogSelectImagePerson.FileName;
            }
        }
    }
}
