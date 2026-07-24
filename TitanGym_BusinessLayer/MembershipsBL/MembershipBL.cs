using System.Data;
using TitanGym_DataAccessLayer.Memberships;

namespace TitanGym_BusinessLayer.MembershipsBL
{
    public class MembershipBL
    {
        ///MembershipID	MembershipName	Duration	MonthlyPrice	Description	AvailabilityStatusID

        public enum EnModeMembersipPlan
        {

            _kADD_NEW_MEMBERSHIP_PLAN = 1,
            _kUPDATE_INFORMATION_MEMBERSHIP_PLAN = 2
        };


        public int MembershipID { get; set; }
        public string MembershipName { get; set; }
        public string Description { get; set; }
        public byte Duration { get; set; }
        public byte AvailabilityStatusID { get; set; }
        public double MonthlyPrice { get; set; }
        public EnModeMembersipPlan ModeMembershipPlan { get; set; }

        public MembershipBL(

            int membershipID,
            string membershipName,
            string description,
            byte duration,
            byte availabilityStatusID,
            double monthlyPrice
            )

        {
            this.MembershipID = membershipID;
            this.MembershipName = membershipName;
            this.Description = description;
            this.Duration = duration;
            this.AvailabilityStatusID = availabilityStatusID;
            this.MonthlyPrice = monthlyPrice;
            this.ModeMembershipPlan = EnModeMembersipPlan._kUPDATE_INFORMATION_MEMBERSHIP_PLAN;
        }

        public MembershipBL()

        {
            this.MembershipID = default;
            this.MembershipName = default;
            this.Description = default;
            this.Duration = default;
            this.AvailabilityStatusID = default;
            this.MonthlyPrice = default;
            this.ModeMembershipPlan = EnModeMembersipPlan._kADD_NEW_MEMBERSHIP_PLAN;
        }

        private bool _AddNewMembershipPlan()
        {
            this.MembershipID = MembershipsDALCommands.InsertNewMembershipPlan(
                this.MembershipName,
                this.Duration,
                this.MonthlyPrice,
                this.Description,
                this.AvailabilityStatusID);

            return this.MembershipID != -1;
        }

        public bool SaveModeMembershipPlan()
        {

            switch (this.ModeMembershipPlan)
            {

                case EnModeMembersipPlan._kADD_NEW_MEMBERSHIP_PLAN:
                    ModeMembershipPlan = EnModeMembersipPlan._kUPDATE_INFORMATION_MEMBERSHIP_PLAN;
                    return _AddNewMembershipPlan();

                case EnModeMembersipPlan._kUPDATE_INFORMATION_MEMBERSHIP_PLAN:
                    return false;

                default: return false;
            }
        }

        public static DataTable GetAllInformationMembershipPlans()
            => MembershipsDALQueries.GetAllMembershipPlans();

        public static bool IsMembershipPlanNameExists(string membershipName)
            => MembershipsDALQueries.IsMembershipExistsBy(membershipName);
    }
}
