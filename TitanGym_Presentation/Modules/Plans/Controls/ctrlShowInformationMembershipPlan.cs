using System.Drawing;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MembershipsBL;

namespace TitanGym_Presentation.Modules.Plans.Controls
{
    public partial class ctrlShowInformationMembershipPlan : UserControl
    {

        public Color BackColorControl
        {
            set
            {
                this.BackColor = value;
            }
        }

        private MembershipBL _InformationMembershipPlan;

        private void _DefaultValues()
        {
            lblMembershipPlanName.Text = "[???]";
            lblDuration.Text = "[???]";
            lblMonthlySalary.Text = "[???]";
            lblDescriptionMembership.Text = "[???]";
            lblAvailabilityStatus.Text = "[???]";
        }

        public void LoadInformationMembershipPlan(byte MembershipPlanID)
        {

            if (MembershipPlanID <= 0) return;

            _InformationMembershipPlan = MembershipBL.FindMembershipBy(MembershipPlanID);

            if (_InformationMembershipPlan is null)
            {
                _DefaultValues();
                MessageBox.Show("This membership plan not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblMembershipPlanName.Text = _InformationMembershipPlan.MembershipName;
            lblDuration.Text = _InformationMembershipPlan.Duration.ToString();
            lblMonthlySalary.Text = _InformationMembershipPlan.MonthlyPrice.ToString("C");
            lblDescriptionMembership.Text = _InformationMembershipPlan.Description;
            lblAvailabilityStatus.Text = _InformationMembershipPlan.InformationAvailabilityStatus.NameAvailabilityStatus;


        }
        public ctrlShowInformationMembershipPlan()
        {
            InitializeComponent();
        }
    }
}
