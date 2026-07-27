using System;
using System.Data;
using System.Windows.Forms;
using TitanGym_BusinessLayer.UsersBL;

namespace TitanGym_Presentation.Modules.Users.Forms
{
    public partial class UCUsersList : UserControl
    {
        private DataTable _DT_AllUsers;

        public UCUsersList()
        {
            InitializeComponent();
        }

        private void _LoadAllInformationusersInDGV()
        {
            _DT_AllUsers = UserBL.GetAllUsers();
            GDataGridViewUsers.DataSource = _DT_AllUsers;

            if (GDataGridViewUsers.Rows.Count > 0)
            {

                GDataGridViewUsers.Columns[0].HeaderText = "USER ID";
                GDataGridViewUsers.Columns[0].Width = 50;

                GDataGridViewUsers.Columns[1].HeaderText = "PERSON ID";
                GDataGridViewUsers.Columns[1].Width = 50;

                GDataGridViewUsers.Columns[2].HeaderText = "FULL NAME USER";
                GDataGridViewUsers.Columns[2].Width = 200;

                GDataGridViewUsers.Columns[3].HeaderText = "USERNAME";
                GDataGridViewUsers.Columns[3].Width = 150;

                GDataGridViewUsers.Columns[4].HeaderText = "CREATION DATE";
                GDataGridViewUsers.Columns[4].Width = 100;

                GDataGridViewUsers.Columns[5].HeaderText = "STATUS ACCOUNT";
                GDataGridViewUsers.Columns[5].Width = 120;

                GDataGridViewUsers.Columns[6].HeaderText = "ROLE";
                GDataGridViewUsers.Columns[6].Width = 120;

            }

            lblTotalUsers.Text = GDataGridViewUsers.Rows.Count.ToString();
        }

        private void UCUsersList_Load(object sender, EventArgs e)
        {
            _LoadAllInformationusersInDGV();

        }
    }
}
