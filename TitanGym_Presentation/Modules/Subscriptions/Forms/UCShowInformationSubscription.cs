using System;
using System.Windows.Forms;

namespace TitanGym_Presentation.Modules.Subscriptions.Forms
{
    public partial class UCShowInformationSubscription : UserControl
    {
        private int _SubscriptionID = -1;
        public event Action<bool> FinishedShowInfoSubscription;

        public UCShowInformationSubscription(int subscriptionID)
        {
            InitializeComponent();
            _SubscriptionID = subscriptionID;
        }

        private void UCShowInformationSubscription_Load(object sender, System.EventArgs e)
        {
            ctrlShowInformationSubscription1.LoadInformationSubscription(_SubscriptionID);
            FinishedShowInfoSubscription?.Invoke(false);
        }

        private void GGButtonBack_Click(object sender, EventArgs e)
        {
            AppNavigator.Back();
        }
    }
}
