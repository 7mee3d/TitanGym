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

        public SubscriptionBL InformatioNSubscription { get { return _InformationSubscription; } }
        public int SubscriptionID { get { return _SubscriptionID; } }

        public bool EnableControls
        {
            set
            {
                GGButtonAddNewSubscription.Enabled = value;
                GGButtonSearchSubscription.Enabled = value;
                GTextBoxSubscriptionID.Enabled = value;
            }

        }

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

        public void LoadInformationSubscription(int subscriptionID)
        {

            if (subscriptionID <= 0) return;
            _InformationSubscription = SubscriptionBL.FindTheSubscriptionBy(subscriptionID);

            if (_InformationSubscription is null)
            {
                ctrlShowInformationSubscription1.DefaultValues();
                MessageBox.Show("This subscription is not exists", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _SubscriptionID = subscriptionID;
            GTextBoxSubscriptionID.Text = _SubscriptionID.ToString();
            ctrlShowInformationSubscription1.LoadInformationSubscription(subscriptionID);
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
