using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;
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

            if (!string.IsNullOrWhiteSpace(GPictureBoxImagePerson.ImageLocation))
                _InformationPerson.ImagePath = Utility.SaveTheImage(GPictureBoxImagePerson.ImageLocation);

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
           => AppNavigator.Back();

        private void UCAddEditPerson_Load(object sender, EventArgs e)
        {
            _DefaultValues();
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

    }
}
