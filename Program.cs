using System;
using System.Windows.Forms;

class Program
{
    static WebBrowser browser;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();

        Form form = new Form();
        form.Text = "Outlook - Supervisor Línea 2";
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

        Button btnSalir = new Button();
        btnSalir.Text = "Salir";
        btnSalir.Left = 250;
        btnSalir.Top = 8;

        browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;

        btnLocal.Click += (s,e) => browser.Navigate("https://lim-sc01/owa");
        btnExterno.Click += (s,e) => browser.Navigate("https://mail.supervisorlinea2.com/owa");
        btnSalir.Click += (s,e) => form.Close();

        topBar.Controls.Add(btnLocal);
        topBar.Controls.Add(btnExterno);
        topBar.Controls.Add(btnSalir);

        form.Controls.Add(browser);
        form.Controls.Add(topBar);

        Application.Run(form);
    }
}
