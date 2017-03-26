using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class ListView_WOC : ScrollableControl
{
    private bool _vertical = true;
    private bool _autoExpand = false;
    private List<Control> _items = new List<Control>();

    public ListView_WOC()
    {
        AutoScroll = true;
    }

    public void add(Control item)
    {
        item.Dock = _vertical ? DockStyle.Top : DockStyle.Left;
        _items.Add(item);
        this.Controls.Add(item);
        item.BringToFront();

        if (_autoExpand && _vertical)
            Height = _items.Last().Location.Y + _items.Last().Size.Height;
        else if (_autoExpand && !_vertical)
            Width = _items.Last().Location.X + _items.Last().Size.Width;
    }

    public void remove(int index)
    {
        this.Controls.Remove(_items.ElementAt(index));
        _items.RemoveAt(index);
    }

    public void clear()
    {
        _items.Clear();
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

    public List<Control> ListItems
    {
        get { return _items; }
        set { _items = value; }
    }

}
