using System;
using System.Windows.Forms;
using TitanGym_BusinessLayer.SubscriptionBL;
using TitanGym_Presentation.Modules.Subscriptions.Forms;

namespace TitanGym_Presentation.Modules.Subscriptions.Controls
{
    public partial class ctrlShowInformationSubscriptionByFilter : UserControl
    {
        public ctrlShowInformationSubscriptionByFilter()
        {
            InitializeComponent();
        }

        private SubscriptionBL _InformationSubscription;
        private int _SubscriptionID = -1;

        public int SubscriptionID { get { return _SubscriptionID; } }

        private void GGButtonSearchSubscription_Click(object sender, EventArgs e)
        {
            int SubscirptionID = Convert.ToInt32(GTextBoxSubscriptionID.Text.Trim());

            _InformationSubscription = SubscriptionBL.FindTheSubscriptionBy(SubscirptionID);

            if (_InformationSubscription is null)
            {
                MessageBox.Show("This subscription is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SubscriptionID = SubscirptionID;
            ctrlShowInformationSubscription1.LoadInformationSubscription(SubscirptionID);
        }

        private void GGButtonAddNewSubscription_Click(object sender, EventArgs e)
        {
            var ucAddEditSubscription = new UCAddEditSubscription();

            ucAddEditSubscription.FinishedAddEditSubscription += result =>
            {
                if (result.IsAddSubscription)
                {
                    GTextBoxSubscriptionID.Text = result.SubscriptionID.ToString();
                    _SubscriptionID = result.SubscriptionID;
                    ctrlShowInformationSubscription1.LoadInformationSubscription(result.SubscriptionID);
                }
            };

            AppNavigator.Show(ucAddEditSubscription);
        }
    }
}
