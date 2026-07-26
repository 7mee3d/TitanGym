using System.Windows.Forms;
using TitanGym_BusinessLayer.SubscriptionBL;

namespace TitanGym_Presentation.Modules.Subscriptions.Controls
{
    public partial class ctrlShowInformationSubscription : UserControl
    {
        private SubscriptionBL _InformationSubscription;

        public ctrlShowInformationSubscription()
        {
            InitializeComponent();
        }

        private void _DefaultValues()
        {

            lblMembershipType.Text = "[???]";
            lblSubscriptionEndDate.Text = "[???]";
            lblSubscriptionStartDate.Text = "[???]";
            lblSubscriptionID.Text = "[???]";
            lblSubscriptionStatus.Text = "[???]";
            lblSubscriptionFees.Text = "[???]";
            ctrlShowInformationMember1._DefaultValuesMember();
        }

        public void LoadInformationSubscription(int SubscriptionID)
        {

            if (SubscriptionID <= 0) return;

            _InformationSubscription = SubscriptionBL.FindTheSubscriptionBy(SubscriptionID);

            if (_InformationSubscription is null)
            {
                _DefaultValues();
                MessageBox.Show("This subscription is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblMembershipType.Text = _InformationSubscription.InformationMembership.MembershipName;
            lblSubscriptionEndDate.Text = _InformationSubscription.EndDate.ToString("dd/MM/yyyy");
            lblSubscriptionStartDate.Text = _InformationSubscription.StartDate.ToString("dd/MM/yyyy");
            lblSubscriptionID.Text = _InformationSubscription.SubscriptionID.ToString();
            lblSubscriptionStatus.Text = _InformationSubscription.InformatioNSubscriptionStatus.NameSubscriptionStatus;
            lblSubscriptionFees.Text = _InformationSubscription.SubscriptionFees.ToString("C");

            ctrlShowInformationMember1.LoadInformationMember(_InformationSubscription.MemberID);
        }
    }
}
