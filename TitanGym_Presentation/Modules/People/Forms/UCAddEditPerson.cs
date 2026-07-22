using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;
using TitanGym_Presentation.Core.Utility;
using TitanGym_Presentation.Core.Validation;
using TitanGym_Presentation.Properties;

namespace TitanGym_Presentation.Modules.People.Forms
{
    public partial class UCAddEditPerson : UserControl
    {
        private enum _EnModePerson : byte
        {
            _kADD_NEW_PERSON = 1,
            _kUPDATE_INFORMATION_PERSON = 2
        }


        private PeopleBL _InformationPerson;
        private readonly int _PersonID;
        private _EnModePerson _ModePerson = _EnModePerson._kADD_NEW_PERSON;
        public event Action<bool> FinihedAddEditPerson;


        public UCAddEditPerson()
        {
            InitializeComponent();
            _ModePerson = _EnModePerson._kADD_NEW_PERSON;
        }

        public UCAddEditPerson(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
            _ModePerson = _EnModePerson._kUPDATE_INFORMATION_PERSON;
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
            _InformationPerson.DateOfBirth = new DateTime(GDateTimePickerPerson.Value.Year, GDateTimePickerPerson.Value.Month, GDateTimePickerPerson.Value.Day);

        }

        private bool _PrepareTheContraintsPeopleSection()
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                  "Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                  "Validation Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );
                return false;
            }

            if (!GGButtonFemale.Checked && !GGButtonMale.Checked)
            {
                MessageBox.Show(
                     "Must Select The Gender",
                     "Validation Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error
                     );
                return false;
            }

            return true;
        }

        private void _AddNewPerson()
        {

            if (!_PrepareTheContraintsPeopleSection()) return;

            _PrepareInformationPerson();

            _HandleImagePerson();

            if (_InformationPerson.SaveModePerson())
            {
                if (_ModePerson == _EnModePerson._kADD_NEW_PERSON)
                    MessageBox.Show("The Person Added Sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Person Updated Sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FinihedAddEditPerson?.Invoke(true);
            }
            else MessageBox.Show("The Person Added Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GGButtonAddNewPerson.Text = "Update Person";
            _ModePerson = _EnModePerson._kUPDATE_INFORMATION_PERSON;
            lblTitlePerson.Text = "Update Person";
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


            _InformationPerson = PeopleBL.FindThePersonBy(_PersonID);
            if (!string.IsNullOrWhiteSpace(_InformationPerson.ImagePath))
            {
                GGButtonDeleteImagePerson.Visible = true;
                GGButtonUpload.Visible = false;
            }
            if (_InformationPerson == null) return;

            GGButtonAddNewPerson.Text = "Update Person";
            lblTitlePerson.Text = "Update Person";
        }

        private void _HandleImagePerson()
        {
            if (_ModePerson == _EnModePerson._kADD_NEW_PERSON)
            {
                if (!string.IsNullOrWhiteSpace(GPictureBoxImagePerson.ImageLocation))
                    _InformationPerson.ImagePath = Utility.SaveTheImage(GPictureBoxImagePerson.ImageLocation);

                return;
            }

            if (_InformationPerson.ImagePath == GPictureBoxImagePerson.ImageLocation) return;


            if (!string.IsNullOrWhiteSpace(_InformationPerson.ImagePath))
            {
                if (Utility.DeleteImageFromFile(_InformationPerson.ImagePath))
                    if (!string.IsNullOrWhiteSpace(GPictureBoxImagePerson.ImageLocation))
                        _InformationPerson.ImagePath = Utility.SaveTheImage(GPictureBoxImagePerson.ImageLocation);
                    else _InformationPerson.ImagePath = null;
                return;
            }
            else
                _InformationPerson.ImagePath = Utility.SaveTheImage(GPictureBoxImagePerson.ImageLocation);

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
           => AppNavigator.Back();

        private void _LoadInformationPersonToControls()
        {


            if (_InformationPerson != null)
            {
                GTextBoxFirstName.Text = _InformationPerson.FirstName;
                GTextBoxSecondName.Text = _InformationPerson.SecondName;
                GTextBoxThirdName.Text = _InformationPerson.ThirdName;
                GTextBoxThirdName.Text = _InformationPerson.LastName;

                GTextBoxResidentialAddress.Text = _InformationPerson.ResidentialAddress;

                if (_InformationPerson.Gender == 'M')
                    GGButtonMale.Checked = true;
                else GGButtonFemale.Checked = true;

                GTextBoxEmailAddress.Text = _InformationPerson.EmailAddress;
                GTextBoxPhoneNumber.Text = _InformationPerson.PhoneNumber;
                GDateTimePickerPerson.Value = _InformationPerson.DateOfBirth;

                if (!string.IsNullOrWhiteSpace(_InformationPerson.ImagePath))
                    GPictureBoxImagePerson.ImageLocation = Utility.DirectoryPath + _InformationPerson.ImagePath;
            }
        }

        private void UCAddEditPerson_Load(object sender, EventArgs e)
        {
            _DefaultValues();

            if (_ModePerson == _EnModePerson._kUPDATE_INFORMATION_PERSON)
                _LoadInformationPersonToControls();
        }

        private void GGButtonAddNewPerson_Click(object sender, EventArgs e)
            => _AddNewPerson();

        private void GGButtonUpload_Click(object sender, EventArgs e)
        {

            openFileDialogSelectImagePerson.Title = "Select image person";
            openFileDialogSelectImagePerson.RestoreDirectory = true;
            openFileDialogSelectImagePerson.Filter = "PNG IMAGE|*.png|JPGE IAMGE|*jpge";
            // openFileDialogSelectImagePerson.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialogSelectImagePerson.ShowDialog() == DialogResult.OK)
            {
                GPictureBoxImagePerson.ImageLocation = openFileDialogSelectImagePerson.FileName;
                GGButtonUpload.Visible = false;
                GGButtonDeleteImagePerson.Visible = (GPictureBoxImagePerson.ImageLocation != "");
            }
        }

        private void ValidationTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox G2TB = sender as Guna2TextBox;

            if (string.IsNullOrWhiteSpace(G2TB.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProviderPeopleSection.SetError(G2TB, "This text box empty");
            }
            else e.Cancel = false;

        }

        private void GTextBoxEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GTextBoxEmailAddress.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProviderPeopleSection.SetError(GTextBoxEmailAddress, "The Text Box Empty");
            }
            else e.Cancel = false;


            if (!Validation.ValidationEmail(GTextBoxEmailAddress.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProviderPeopleSection.SetError(GTextBoxEmailAddress, "The Not Valid");
            }
            else e.Cancel = false;
        }

        private void GGButtonDeleteImagePerson_Click(object sender, EventArgs e)
        {
            GPictureBoxImagePerson.ImageLocation = null;
            GPictureBoxImagePerson.Image = Resources.account_circle_Icon_TitanGym_50;
            GGButtonUpload.Visible = (GPictureBoxImagePerson.ImageLocation == null);
        }
    }
}
