using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessUISample.Childs
{
    public partial class Other_ListView_Child : UserControl
    {
        public Other_ListView_Child(string text)
        {
            InitializeComponent();
            textBox_WOC1.TextBox.Text = text;
        }
    }
}
