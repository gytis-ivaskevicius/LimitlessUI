using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LimitlessUISample.Childs
{
    public partial class Other_ListView_Child : UserControl
    {
        Random _random;
        Color[] colorsArray = { Color.Red, Color.Green, Color.Yellow, Color.Purple, Color.Blue, Color.Brown, Color.Black, Color.White, Color.Orange,Color.Magenta };
        public Other_ListView_Child(string text)
        {
            InitializeComponent();
            _random = new Random(Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value));
            textBox_WOC1.Text = text;
            textBox_WOC1.AnimationColor = getRandomColor();
        }

        private Color getRandomColor()
        {
            return colorsArray[_random.Next(colorsArray.Length)];
        }
    }
}
