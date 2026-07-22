using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanGym_BusinessLayer.PeopleBL;

namespace TitanGym_Presentation.Modules.People.Forms
{
    public partial class UCPeopleList : UserControl
    {
        private DataTable DT_AllPeople;

        public UCPeopleList()
        {
            InitializeComponent();
        }

        private void _LoadAllInformationPeopleInDGV()
        {

            DT_AllPeople = PeopleBL.GetAllPeople();
            GDataGridViewPeople.DataSource = DT_AllPeople;

            if (GDataGridViewPeople.Rows.Count > 0)
            {

                GDataGridViewPeople.Columns[0].HeaderText = "PERSON ID";
                GDataGridViewPeople.Columns[0].Width = 80;

                GDataGridViewPeople.Columns[1].HeaderText = "First Name";
                GDataGridViewPeople.Columns[1].Width = 150;

                GDataGridViewPeople.Columns[2].HeaderText = "SECOND NAME";
                GDataGridViewPeople.Columns[2].Width = 150;

                GDataGridViewPeople.Columns[3].HeaderText = "THIRD NAME";
                GDataGridViewPeople.Columns[3].Width = 150;

                GDataGridViewPeople.Columns[4].HeaderText = "LAST NAME";
                GDataGridViewPeople.Columns[4].Width = 150;

                GDataGridViewPeople.Columns[5].HeaderText = "GENDOR";
                GDataGridViewPeople.Columns[5].Width = 80;

                GDataGridViewPeople.Columns[6].HeaderText = "PHONE NUMBER";
                GDataGridViewPeople.Columns[6].Width = 150;

                GDataGridViewPeople.Columns[7].HeaderText = "EMAIL ADDRESS";
                GDataGridViewPeople.Columns[7].Width = 200;

                GDataGridViewPeople.Columns[8].HeaderText = "RESIDENTIAL ADDRESS";
                GDataGridViewPeople.Columns[8].Width = 250;

                GDataGridViewPeople.Columns[9].HeaderText = "DATE OF BIRTH";
                GDataGridViewPeople.Columns[9].Width = 150;

            }
        }

        private void UCPeopleList_Load(object sender, EventArgs e)
        {
            _LoadAllInformationPeopleInDGV();
        }

        private void GGButtonAddNewPerson_Click(object sender, EventArgs e)
        {
            AppNavigator.Show(new UCAddEditPerson());
        }
    }
}
