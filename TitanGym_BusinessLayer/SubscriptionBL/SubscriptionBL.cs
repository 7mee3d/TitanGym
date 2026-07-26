using System;
using System.Data;
using TitanGym_BusinessLayer.MembershipsBL;
using TitanGym_DataAccessLayer.Subscriptions;

namespace TitanGym_BusinessLayer.SubscriptionBL
{
    public class SubscriptionBL
    {


        public enum EnModeSubscription
        {
            _kADD_NEW_SUBSCRIPTION = 1,
            _kUPDATE_INFORMATION_SUBSCRIPTION = 2
        }

        public int SubscriptionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double SubscriptionFees { get; set; }
        public byte SubscriptionStatusID { get; set; }
        public int MemberID { get; set; }
        public int MembershipID { get; set; }
        public EnModeSubscription ModeSubscription { get; set; }

        private MemberBL.MemberBL _InformationMember;

        public MemberBL.MemberBL InformationMember
        {

            get
            {
                if (_InformationMember is null)
                    _InformationMember = MemberBL.MemberBL.FindTheMemberBy(this.MemberID);

                return _InformationMember;
            }


        }

        private MembershipsBL.MembershipBL _InformationMembership;
        public MembershipsBL.MembershipBL InformationMembership
        {
            get
            {
                if (_InformationMembership is null)
                    _InformationMembership = MembershipBL.FindMembershipBy(this.MembershipID);

                return _InformationMembership;
            }
        }

        public SubscriptionBL(

            int subscriptionID,
            DateTime startDate,
            DateTime endDate,
            double subscriptionFees,
            byte subscriptionStatusID,
            int memberID,
            int membershipID
            )

        {
            this.SubscriptionID = subscriptionID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SubscriptionFees = subscriptionFees;
            this.SubscriptionStatusID = subscriptionStatusID;
            this.MemberID = memberID;
            this.MembershipID = membershipID;
            this.ModeSubscription = EnModeSubscription._kUPDATE_INFORMATION_SUBSCRIPTION;
        }

        public SubscriptionBL()
        {
            this.SubscriptionID = default;
            this.StartDate = default;
            this.EndDate = default;
            this.SubscriptionFees = default;
            this.SubscriptionStatusID = default;
            this.MemberID = default;
            this.MembershipID = default;
            this.ModeSubscription = EnModeSubscription._kADD_NEW_SUBSCRIPTION;
        }

        public static SubscriptionBL FindTheSubscriptionBy(int SubscriptionID)
        {

            DateTime startDate = DateTime.Now, endDate = DateTime.Now;

            double subscriptionFees = 0.0d;
            byte subscriptionStatusID = 0;

            int memberID = 0, membershipID = 0;

            bool IsFounded = SubscriptionDALQueries.FindTheSubscriptionBy(

                SubscriptionID,
                ref startDate,
                ref endDate,
                ref subscriptionFees,
                ref subscriptionStatusID,
                ref memberID,
                ref membershipID
                );

            if (IsFounded)
                return new SubscriptionBL(

                    SubscriptionID,
                    startDate,
                    endDate,
                    subscriptionFees,
                    subscriptionStatusID,
                    memberID,
                    membershipID
                    );

            else return null;

        }

        public static DataTable GetAllSubscription()
                => SubscriptionDALQueries.GetAllSubscription();

        private bool _AddNewSubscription()
        {
            this.SubscriptionID = SubscriptionsDALCommands.InsertNewSubscription(
                StartDate,
                EndDate,
                SubscriptionFees,
                SubscriptionStatusID,
                MemberID,
                MembershipID
                );

            return this.SubscriptionID != -1;
        }

        private bool _UpdateInformationSubscription()
        {
            return SubscriptionsDALCommands.UpdateInformationSubscription(
                SubscriptionID,
                  StartDate,
                  EndDate,
                  SubscriptionFees,
                  SubscriptionStatusID,
                  MemberID,
                  MembershipID
                  );

        }

        public bool SaveModeSubscription()
        {

            switch (this.ModeSubscription)
            {
                case EnModeSubscription._kADD_NEW_SUBSCRIPTION:
                    if (_AddNewSubscription())
                    {
                        this.ModeSubscription = EnModeSubscription._kUPDATE_INFORMATION_SUBSCRIPTION;
                        return true;
                    }

                    return false;

                case EnModeSubscription._kUPDATE_INFORMATION_SUBSCRIPTION:
                    return _UpdateInformationSubscription();

                default: return false;
            }
        }

        public bool ExpireSubscription()
        {

            if (this.SubscriptionStatusID == 2 || this.SubscriptionStatusID == 3 || this.SubscriptionStatusID == 4)
                return false;

            if (this.EndDate > DateTime.Now) return false;

            this.SubscriptionStatusID = 2;
            this.ModeSubscription = EnModeSubscription._kUPDATE_INFORMATION_SUBSCRIPTION;

            if (!SaveModeSubscription()) return false;


            return true;

        }
    }
}
