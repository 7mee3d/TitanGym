using Guna.UI2.WinForms;
using System;

namespace TitanGym_Presentation.Core.Helpers
{
    public static class HelpersPL
    {
        public static T GetValueFromDataGridView<T>(this Guna2DataGridView G2DGV, int cell)
         => (T)Convert.ChangeType(G2DGV.SelectedRows[0].Cells[cell].Value.ToString(), typeof(T));
    }
}
