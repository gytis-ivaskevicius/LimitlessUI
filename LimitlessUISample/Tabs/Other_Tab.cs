using System.Windows.Forms;
using LimitlessUISample.Childs;
using System.Diagnostics;
using LimitlessUI;

namespace LimitlessUISample.Tabs
{
    public partial class Other_Tab : UserControl, Tab_WOC
    {
        private static Other_Tab _instance;

        public Other_Tab()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
                listView_WOC1.Add(new Other_ListView_Child(" Amazing ListView Child " + i));
        }

        public static Other_Tab GetInstance()
        {
            if (_instance == null)
                _instance = new Other_Tab();
            return _instance;
        }

        public void OnShowTab()
        {
            Debug.WriteLine("Showing Gradient_Tab");
        }
    }
}