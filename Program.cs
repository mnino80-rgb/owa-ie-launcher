using System;
using System.Windows.Forms;

class Program
{
    static WebBrowser browser;

    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();

        string url = null;

        if (args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "local":
                    url = "https://lim-sc01/owa";
                    break;

                case "externo":
                    url = "https://mail.supervisorlinea2.com/owa";
                    break;

                case "demo":
                    url = "https://demo-sc.local/";
                    break;

                default:
                    url = args[0];
                    break;
            }
        }

        Form form = new Form();
        form.Text = "Outlook Web - Supervisor Línea 2";
        form.WindowState = FormWindowState.Maximized;

        Panel topBar = new Panel();
        topBar.Height = 40;
        topBar.Dock = DockStyle.Top;

        Button btnLocal = new Button();
        btnLocal.Text = "Correo Local";
        btnLocal.Left = 10;
        btnLocal.Top = 8;

        Button btnExterno = new Button();
        btnExterno.Text = "Correo Externo";
        btnExterno.Left = 120;
        btnExterno.Top = 8;

        Button btnDemo = new Button();
        btnDemo.Text = "Demo";
        btnDemo.Left = 250;
        btnDemo.Top = 8;

        Button btnSalir = new Button();
        btnSalir.Text = "Salir";
        btnSalir.Left = 330;
        btnSalir.Top = 8;

        browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.ScriptErrorsSuppressed = true;

        btnLocal.Click += (s,e) => browser.Navigate("https://lim-sc01/owa");
        btnExterno.Click += (s,e) => browser.Navigate("https://mail.supervisorlinea2.com/owa");
        btnDemo.Click += (s,e) => browser.Navigate("https://demo-sc.local/");
        btnSalir.Click += (s,e) => form.Close();

        topBar.Controls.Add(btnLocal);
        topBar.Controls.Add(btnExterno);
        topBar.Controls.Add(btnDemo);
        topBar.Controls.Add(btnSalir);

        form.Controls.Add(browser);
        form.Controls.Add(topBar);

        if (url != null)
            browser.Navigate(url);

        Application.Run(form);
    }
}
