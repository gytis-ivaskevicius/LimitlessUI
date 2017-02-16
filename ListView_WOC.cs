using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class ListView_WOC : ScrollableControl
{
    private bool vertical = true;
    private bool autoExpand = false;
    public List<Control> items = new List<Control>();

    public ListView_WOC()
    {
        AutoScroll = true;
    }

    public void add(Control item)
    {
        item.Dock = vertical ? DockStyle.Top : DockStyle.Left;
        items.Add(item);
        this.Controls.Add(item);
        item.BringToFront();

        if (autoExpand && vertical)
            Height = items.Last().Location.Y + items.Last().Size.Height;
        else if (autoExpand && !vertical)
            Width = items.Last().Location.X + items.Last().Size.Width;
    }

    public void remove(int index)
    {
        this.Controls.Remove(items.ElementAt(index));
        items.RemoveAt(index);
    }

    public void clear()
    {
        items.Clear();
        this.Controls.Clear();
    }

    public bool Vertical
    {
        get { return vertical; }
        set { vertical = value; }
    }

    public bool AutoExpand
    {
        get { return autoExpand; }
        set { autoExpand = value; }
    }
}
