using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MembershipsBL;

namespace TitanGym_Presentation.Modules.Plans.Forms
{
    public partial class UCMembershipPlansList : UserControl
    {
        public UCMembershipPlansList()
        {
            InitializeComponent();
        }

        private DataTable _DT_AllInformationMembershipPlans;

        private void _LoadInformationMembershipPlans()
        {
            _DT_AllInformationMembershipPlans = MembershipBL.GetAllInformationMembershipPlans();
            GDataGridViewMembershipPlans.DataSource = _DT_AllInformationMembershipPlans;

            if (GDataGridViewMembershipPlans.Rows.Count > 0)
            {//MembershipID	MembershipName	Duration	MonthlyPrice	Description	AvailabilityStatusID

                GDataGridViewMembershipPlans.Columns[0].HeaderText = "MEMBERSHIP ID";
                GDataGridViewMembershipPlans.Columns[0].Width = 60;

                GDataGridViewMembershipPlans.Columns[1].HeaderText = "MEMBERSHIP NAME";
                GDataGridViewMembershipPlans.Columns[1].Width = 80;

                GDataGridViewMembershipPlans.Columns[2].HeaderText = "DURATION";
                GDataGridViewMembershipPlans.Columns[2].Width = 50;

                GDataGridViewMembershipPlans.Columns[3].HeaderText = "MONTHLY PRICE";
                GDataGridViewMembershipPlans.Columns[3].Width = 60;

                GDataGridViewMembershipPlans.Columns[4].HeaderText = "DESCRIPTION";
                GDataGridViewMembershipPlans.Columns[4].Width = 200;

                GDataGridViewMembershipPlans.Columns[5].HeaderText = "AVAILABILITY STATUS";
                GDataGridViewMembershipPlans.Columns[5].Width = 150;

            }
        }
        private void UCMembershipPlansList_Load(object sender, EventArgs e)
        {
            _LoadInformationMembershipPlans();
        }
    }
}
