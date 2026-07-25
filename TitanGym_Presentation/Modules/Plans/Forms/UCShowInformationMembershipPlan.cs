using System;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Plans.Forms
{
    public partial class UCShowInformationMembershipPlan : UserControl
    {
        private byte _MembershipPlanID = 0;
        public event Action<bool> FinishedShowInfoMembershipPlan;

        public UCShowInformationMembershipPlan(byte MembershipPlanID)
        {
            InitializeComponent();
            _MembershipPlanID = MembershipPlanID;

        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }

        private void UCShowInformationMembershipPlan_Load(object sender, EventArgs e)
        {
            ctrlShowInformationMembershipPlan1.LoadInformationMembershipPlan(_MembershipPlanID);
            FinishedShowInfoMembershipPlan?.Invoke(false);
        }
    }
}
