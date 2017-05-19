using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class ListView_WOC : ScrollableControl
{
    private bool _vertical = true;
    private bool _autoExpand = false;
    public List<Control> items = new List<Control>();

    public ListView_WOC()
    {
        AutoScroll = true;
    }

    public void add(Control item)
    {
        item.Dock = _vertical ? DockStyle.Top : DockStyle.Left;
        items.Add(item);
        this.Controls.Add(item);
        item.BringToFront();

        if (_autoExpand && _vertical)
            Height = items.Last().Location.Y + items.Last().Size.Height;
        else if (_autoExpand && !_vertical)
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
        get { return _vertical; }
        set { _vertical = value; }
    }

    public bool AutoExpand
    {
        get { return _autoExpand; }
        set { _autoExpand = value; }
    }
}