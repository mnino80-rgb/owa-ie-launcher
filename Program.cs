using System;
using System.Windows.Forms;

class Program
{
    static TabControl tabs;
    static TextBox addressBar;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();

        Form selector = new Form();
        selector.Text = "Abrir Correo OWA";
        selector.Width = 300;
        selector.Height = 180;
        selector.StartPosition = FormStartPosition.CenterScreen;

        Button btnLocal = new Button();
        btnLocal.Text = "Local - lim-sc01";
        btnLocal.Width = 200;
        btnLocal.Top = 20;
        btnLocal.Left = 40;

        Button btnExterno = new Button();
        btnExterno.Text = "Externo - mail.supervisor";
        btnExterno.Width = 200;
        btnExterno.Top = 70;
        btnExterno.Left = 40;

        btnLocal.Click += (s,e) => AbrirNavegador("https://lim-sc01/owa");
        btnExterno.Click += (s,e) => AbrirNavegador("https://mail.supervisorlinea2.com/owa");

        selector.Controls.Add(btnLocal);
        selector.Controls.Add(btnExterno);

        Application.Run(selector);
    }

    static void AbrirNavegador(string url)
    {
        Form browserForm = new Form();
        browserForm.Text = "OWA Browser";
        browserForm.WindowState = FormWindowState.Maximized;

        ToolStrip toolbar = new ToolStrip();

        ToolStripButton back = new ToolStripButton("←");
        ToolStripButton forward = new ToolStripButton("→");
        ToolStripButton refresh = new ToolStripButton("⟳");
        ToolStripButton newTab = new ToolStripButton("+");

        ToolStripControlHost addressHost;
        addressBar = new TextBox();
        addressBar.Width = 400;
        addressHost = new ToolStripControlHost(addressBar);

        toolbar.Items.Add(back);
        toolbar.Items.Add(forward);
        toolbar.Items.Add(refresh);
        toolbar.Items.Add(newTab);
        toolbar.Items.Add(addressHost);

        tabs = new TabControl();
        tabs.Dock = DockStyle.Fill;

        browserForm.Controls.Add(tabs);
        browserForm.Controls.Add(toolbar);

        toolbar.Dock = DockStyle.Top;

        NuevaPestana(url);

        newTab.Click += (s,e) => NuevaPestana("https://www.bing.com");

        back.Click += (s,e) =>
        {
            WebBrowser browser = GetBrowser();
            if (browser.CanGoBack) browser.GoBack();
        };

        forward.Click += (s,e) =>
        {
            WebBrowser browser = GetBrowser();
            if (browser.CanGoForward) browser.GoForward();
        };

        refresh.Click += (s,e) =>
        {
            GetBrowser().Refresh();
        };

        addressBar.KeyDown += (s,e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetBrowser().Navigate(addressBar.Text);
            }
        };

        browserForm.Show();
    }

    static void NuevaPestana(string url)
    {
        TabPage page = new TabPage("Nueva pestaña");

        WebBrowser browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.Navigate(url);

        browser.DocumentCompleted += (s,e) =>
        {
            addressBar.Text = browser.Url.ToString();
            page.Text = browser.DocumentTitle;
        };

        page.Controls.Add(browser);
        tabs.TabPages.Add(page);
        tabs.SelectedTab = page;
    }

    static WebBrowser GetBrowser()
    {
        return (WebBrowser)tabs.SelectedTab.Controls[0];
    }
}
