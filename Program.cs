using System;
using System.Net.NetworkInformation;
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

        Label status = new Label();
        status.Text = "Conectando al servidor de correo...";
        status.Dock = DockStyle.Top;
        status.Height = 30;

        browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.ScriptErrorsSuppressed = true;

        form.Controls.Add(browser);
        form.Controls.Add(status);

        string url = DetectarServidor();

        if (url == null)
        {
            MostrarErrorOutlook();
        }
        else
        {
            browser.Navigate(url);
        }

        Application.Run(form);
    }

    static string DetectarServidor()
    {
        try
        {
            Ping ping = new Ping();

            PingReply reply = ping.Send("lim-sc01", 1000);

            if (reply.Status == IPStatus.Success)
                return "https://lim-sc01/owa";
        }
        catch { }

        try
        {
            Ping ping = new Ping();

            PingReply reply = ping.Send("mail.supervisorlinea2.com", 1000);

            if (reply.Status == IPStatus.Success)
                return "https://mail.supervisorlinea2.com/owa";
        }
        catch { }

        return null;
    }

    static void MostrarErrorOutlook()
    {
        MessageBox.Show(
            "No se pudo conectar al servidor de correo.\n\nVerifique su conexión a la red o VPN.",
            "Outlook",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }
}
