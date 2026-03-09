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
        selector.Height = 200;

        Button btnLocal = new Button();
        btnLocal.Text = "Local - lim-sc01";
        btnLocal.Width = 200;
        btnLocal.Top = 30;
        btnLocal.Left = 40;

        Button btnExterno = new Button();
        btnExterno.Text = "Externo - mail.supervisor";
        btnExterno.Width = 200;
        btnExterno.Top = 80;
        btnExterno.Left = 40;

        btnLocal.Click += (s,e) => Abrir("https://lim-sc01/owa");
        btnExterno.Click += (s,e) => Abrir("https://mail.supervisorlinea2.com/owa");

        selector.Controls.Add(btnLocal);
        selector.Controls.Add(btnExterno);

        Application.Run(selector);
    }

    static void Abrir(string url)
    {
        Form form = new Form();
        form.Width = 1200;
        form.Height = 800;

        WebBrowser browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.Navigate(url);

        form.Controls.Add(browser);
        form.Show();
    }
}
