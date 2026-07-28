using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.SubscriptionBL;
using TitanGym_BusinessLayer.Trainer_AssignmentsBL;
using TitanGym_BusinessLayer.TrainersBL;

namespace TitanGym_Presentation.Modules.Trainer_Assignments.Forms
{
    public partial class UCAssigementEditMemberTrainer : UserControl
    {
        private enum _EnModeAssigementMember : byte
        {
            _kASSIGEMENT_MEMBER_TO_TRAINER = 1,
            _kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TO_TRAINER = 2
        };

        private _EnModeAssigementMember _ModeAssigement;
        private TrainerAssignmentsBL _InformationAssigement;
        public event Action<bool> FinishedAddEditAssigemntTrainer;


        public UCAssigementEditMemberTrainer()
        {
            InitializeComponent();
            this._ModeAssigement = _EnModeAssigementMember._kASSIGEMENT_MEMBER_TO_TRAINER;
        }

        private void _LoadInformatioNTrainerInCB()
        {
            GComboBoxTrainers.DisplayMember = "FullName";
            GComboBoxTrainers.ValueMember = "TrainerID";
            GComboBoxTrainers.DataSource = TrainerBL.GetAllTrainers();
        }

        private void _DefaultValues()
        {
            _LoadInformatioNTrainerInCB();
            if (this._ModeAssigement == _EnModeAssigementMember._kASSIGEMENT_MEMBER_TO_TRAINER)
            {
                _InformationAssigement = new TrainerAssignmentsBL();
                lblAssigementMembers.Text = "Assigement Member To Trainer";
                GGButtonAssgementMember.Text = "Assigement Member";
                return;
            }
        }

        private void _PrepareInformationTrainerAssigement()
        {


            _InformationAssigement.TrainerID = Convert.ToInt32(GComboBoxTrainers.SelectedValue);
            _InformationAssigement.AssignmentDate = DateTime.Now;
            _InformationAssigement.MemberID = ctrlShowInformationSubscriptionByFilter1.InformatioNSubscription.MemberID;
            _InformationAssigement.Note = GTextBoxNote.Text.Trim();
        }

        private bool _PreapreConstraintsAssigementTrainer()
        {

            SubscriptionBL InfoSubscription = ctrlShowInformationSubscriptionByFilter1.InformatioNSubscription;

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

            if (InfoSubscription != null)
            {
                if (InfoSubscription.MemberID == -1)
                {
                    MessageBox.Show(
                      "To be assigment member to trainer must enter the member",
                      "Message Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                      );

                    return false;
                }


                if (InfoSubscription.EndDate < DateTime.Today)
                {
                    MessageBox.Show(
                      "The Subscription was Epired",
                      "Message Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                      );

                    return false;
                }

                if (InfoSubscription.SubscriptionStatusID != 1)
                {
                    MessageBox.Show(
                      "The Subscription is Not active",
                      "Message Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                      );

                    return false;
                }
            }
            else return false;

            return true;
        }

        private void _AddNewAssigementTrainer()
        {


            if (!_PreapreConstraintsAssigementTrainer()) return;

            _PrepareInformationTrainerAssigement();

            if (this._InformationAssigement.SaveModeAssigmentTrainer())
            {
                FinishedAddEditAssigemntTrainer?.Invoke(true);
                lblAssigementDateMember.Text = this._InformationAssigement.AssignmentDate.ToString("dd/MM/yyyy");

                if (this._ModeAssigement == _EnModeAssigementMember._kASSIGEMENT_MEMBER_TO_TRAINER)
                    MessageBox.Show("The assiement trainer added sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The assiement trainer updated sccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("The assiement trainer added/updated faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lblAssigementMembers.Text = "Update Assigement Member To Trainer";
            GGButtonAssgementMember.Text = "Update Assigement Member";
            this._ModeAssigement = _EnModeAssigementMember._kUPDATE_INFORMATION_ASSIGEMENT_MEMBER_TO_TRAINER;


        }

        private void UCAssigementEditMemberTrainer_Load(object sender, EventArgs e)
        {
            _DefaultValues();
        }

        private void GGButtonAssgementMember_Click(object sender, EventArgs e)
        {
            _AddNewAssigementTrainer();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void GTextBoxNote_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GTextBoxNote.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderAssigementTrainers.SetError(GTextBoxNote, "This Feild is empty");
            }
            else
                e.Cancel = false;
        }
    }
}
