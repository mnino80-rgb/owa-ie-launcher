using System;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();

        Form selector = new Form();
        selector.Text = "Abrir Correo OWA";
        selector.Width = 300;
        selector.Height = 180;

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
        browserForm.Width = 1200;
        browserForm.Height = 800;

        TabControl tabs = new TabControl();
        tabs.Dock = DockStyle.Fill;

        browserForm.Controls.Add(tabs);

        NuevaPestana(tabs, url);

        browserForm.Show();
    }

    static void NuevaPestana(TabControl tabs, string url)
    {
        TabPage page = new TabPage("OWA");

        WebBrowser browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.Navigate(url);

        page.Controls.Add(browser);
        tabs.TabPages.Add(page);
    }
}
