using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TitanGym_BusinessLayer.MemberBL;
using TitanGym_Presentation.Core.Helpers;
using TitanGym_Presentation.Modules.People.Forms;

namespace TitanGym_Presentation.Modules.Members.Forms
{
    public partial class UCMemberList : UserControl
    {

        private DataTable _DT_AllInfoMembers;

        public UCMemberList()
        {
            InitializeComponent();
        }

        private void _LoadInfomrationMembersInDGV()
        {
            _DT_AllInfoMembers = MemberBL.GetAllMembers();
            GDataGridViewMembers.DataSource = _DT_AllInfoMembers;

            if (GDataGridViewMembers.Rows.Count > 0)
            {
                GDataGridViewMembers.Columns[0].HeaderText = "MEMBER ID";
                GDataGridViewMembers.Columns[0].Width = 70;

                GDataGridViewMembers.Columns[1].HeaderText = "PERSON ID";
                GDataGridViewMembers.Columns[1].Width = 70;

                GDataGridViewMembers.Columns[2].HeaderText = "FULL NAME";
                GDataGridViewMembers.Columns[2].Width = 150;

                GDataGridViewMembers.Columns[3].HeaderText = "MEMBERSHIPE TYPE";
                GDataGridViewMembers.Columns[3].Width = 100;

                GDataGridViewMembers.Columns[4].HeaderText = "MEMBERSHIP STATUS";
                GDataGridViewMembers.Columns[4].Width = 150;

                GDataGridViewMembers.Columns[5].HeaderText = "START DATE";
                GDataGridViewMembers.Columns[5].Width = 60;

                GDataGridViewMembers.Columns[6].HeaderText = "END DATE";
                GDataGridViewMembers.Columns[6].Width = 60;

                GDataGridViewMembers.Columns[7].HeaderText = "EMAIL ADDRESS";
                GDataGridViewMembers.Columns[7].Width = 150;

                GDataGridViewMembers.Columns[8].HeaderText = "PHONE NUMBER";
                GDataGridViewMembers.Columns[8].Width = 150;

            }
        }

        private void _InitalDataHeader()
        {
            lblTotalMembers.Text = _DT_AllInfoMembers.Rows.Count.ToString();
            lblActivePlans.Text = GetTheActivePlans().ToString();
            lblPendingExpiry.Text = MemberBL.GetTheMembersPendingExpireBy(5).ToString();
        }

        private int GetTheActivePlans()
        {
            if (_DT_AllInfoMembers.Rows.Count == 0) return 0;

            int counter = 0;

            foreach (DataRow DR_Member in _DT_AllInfoMembers.Rows)
            {
                if (DR_Member["NameMembershipStatus"].ToString() == "Active")
                    ++counter;
            }

            return counter;
        }

        private void UCMemberList_Load(object sender, EventArgs e)
        {
            _LoadInfomrationMembersInDGV();
            //After Load Info In DGV
            _InitalDataHeader();
        }

        private void GDataGridViewMembers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int counter = 0; counter < _DT_AllInfoMembers.Rows.Count; counter += 1)
            {

                DataGridViewRow DGVR_MemberType = GDataGridViewMembers.Rows[counter];
                DataGridViewCell DGVC_MemberType = DGVR_MemberType.Cells[3];


                string MemberType = DGVC_MemberType.Value.ToString();

                // Membership Type
                switch (MemberType)
                {
                    case "Basic":
                        DGVC_MemberType.Style.ForeColor = Color.FromArgb(229, 231, 235);
                        break;

                    case "Silver":
                        DGVC_MemberType.Style.ForeColor = Color.Silver;
                        break;

                    case "Gold":
                        DGVC_MemberType.Style.ForeColor = Color.FromArgb(250, 204, 21);
                        break;

                    case "Platinum":
                        DGVC_MemberType.Style.ForeColor = Color.FromArgb(103, 232, 249);
                        break;

                    case "VIP":
                        DGVC_MemberType.Style.ForeColor = Color.FromArgb(168, 85, 247);
                        break;
                }

                DataGridViewRow DGVR_MembershipStatus = GDataGridViewMembers.Rows[counter];
                DataGridViewCell DGVC_MembershipStatus = DGVR_MemberType.Cells[4];


                string MembershipStatus = DGVC_MembershipStatus.Value.ToString();



                // Membership Status
                switch (MembershipStatus)
                {
                    case "Active":
                        DGVC_MembershipStatus.Style.ForeColor = Color.FromArgb(34, 197, 94);
                        break;

                    case "Inactive":
                        DGVC_MembershipStatus.Style.ForeColor = Color.FromArgb(156, 163, 175);
                        break;

                    case "Suspended":
                        DGVC_MembershipStatus.Style.ForeColor = Color.FromArgb(249, 115, 22);
                        break;

                    case "Expired":
                        DGVC_MembershipStatus.Style.ForeColor = Color.FromArgb(239, 68, 68);
                        break;

                    case "Pending":
                        DGVC_MembershipStatus.Style.ForeColor = Color.FromArgb(245, 158, 11);
                        break;
                }

            }
        }

        private void GGButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCAddEditInformationMember());
        }

        private void updateInformationMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewMembers, 0);

            var ucAddEditMember = new UCAddEditInformationMember(MemberID);

            ucAddEditMember.EH_FinishedAddEditMember += result =>
            {
                if (result.IsAddOrEditMember) UCMemberList_Load(null, null);
            };

            AppNavigator.Show(ucAddEditMember);
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var ucAddEditMember = new UCAddEditInformationMember();

            ucAddEditMember.EH_FinishedAddEditMember += result =>
            {
                if (result.IsAddOrEditMember) UCMemberList_Load(null, null);
            };

            AppNavigator.Show(ucAddEditMember);

        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to be delete this member ?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                return;

            int MemberID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewMembers, 0);

            if (MemberBL.DeleteMemberBy(MemberID))
            {
                UCMemberList_Load(null, null);
                MessageBox.Show("The member deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("The member deleted Faild", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void showInformationMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = HelpersPL.GetValueFromDataGridView<int>(GDataGridViewMembers, 0);

            var ucShowInformationMember = new UCShowInformationMember(MemberID);

            ucShowInformationMember.EH_FinishedShowInfoMember += result =>
            {
                if (result) UCMemberList_Load(null, null);
            };

            AppNavigator.Show(ucShowInformationMember);

        }
    }
}
