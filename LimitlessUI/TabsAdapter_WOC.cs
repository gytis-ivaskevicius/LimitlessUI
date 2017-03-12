using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


public partial class TabsAdapter_WOC : Component
{
    private Control _control;
    private List<UserControl> _tabs = new List<UserControl>();

    public void addTab(UserControl tab, bool isOnTop)
    {
        _control.Controls.Add(tab);
        tab.Dock = DockStyle.Fill;
        if (isOnTop)
            showTab(tab);
        _tabs.Add(tab);
    }

    public void showTab(int tab)
    {
        showTab(_tabs.ElementAt(tab));
    }

    public void showTab(UserControl tab)
    {
        if (_tabs.Contains(tab))
        {
            if(tab is Tab_WOC)
                ((Tab_WOC)tab).onShowTab();
            tab.BringToFront();
        }
    }

    public List<UserControl> Tabs
    {
        get { return _tabs; }
    }

    public Control Control
    {
        get { return _control; }
        set { _control = value; }
    }
}

