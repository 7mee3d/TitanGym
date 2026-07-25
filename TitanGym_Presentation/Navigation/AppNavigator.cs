using System.Collections.Generic;
using System.Windows.Forms;


namespace TitanGym_Presentation
{
    internal class AppNavigator
    {
        private static Panel _MainPanel;

        private static Stack<UserControl> _ST_UserControls = new Stack<UserControl>();

        public static void Initialization(Panel panel)
        {
            _MainPanel = panel;
        }

        public static void Show(UserControl userControl)
        {
            if (_MainPanel.Controls.Count > 0)
            {
                var current = _MainPanel.Controls[0] as UserControl;

                if (current != null)
                    _ST_UserControls.Push(current);
            }

            _MainPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            _MainPanel.Controls.Add(userControl);
        }

        public static void Back()
        {
            if (_ST_UserControls.Count == 0) return;

            var previous = _ST_UserControls.Pop();

            _MainPanel.Controls.Clear();
            _MainPanel.Controls.Add(previous);
        }
    }
}
