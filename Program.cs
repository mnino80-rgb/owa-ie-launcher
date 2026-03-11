using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace OWAHelper
{
    static class Program
    {
        static WebBrowser browser;

        static void SetBrowserFeatureControl()
        {
            try
            {
                string appName = Path.GetFileName(Application.ExecutablePath);

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
                {
                    if (key != null)
                        key.SetValue(appName, 11001, RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        [STAThread]
        static void Main(string[] args)
        {
            SetBrowserFeatureControl();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();
            form.Text = "Outlook Web - Supervisor Línea 2";
            form.WindowState = FormWindowState.Maximized;

            Panel topBar = new Panel();
            topBar.Height = 40;
            topBar.Dock = DockStyle.Top;

            Button btnLocal = new Button();
            btnLocal.Text = "Local";
            btnLocal.Left = 10;
            btnLocal.Top = 8;

            Button btnExterno = new Button();
            btnExterno.Text = "Externo";
            btnExterno.Left = 100;
            btnExterno.Top = 8;

            Button btnTest = new Button();
            btnTest.Text = "Test";
            btnTest.Left = 200;
            btnTest.Top = 8;

            Button btnSalir = new Button();
            btnSalir.Text = "Salir";
            btnSalir.Left = 290;
            btnSalir.Top = 8;

            browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            browser.ScriptErrorsSuppressed = true;

            btnLocal.Click += (s,e) => browser.Navigate("https://lim-sc01/owa");
            btnExterno.Click += (s,e) => browser.Navigate("https://mail.supervisorlinea2.com/owa");
            btnTest.Click += (s,e) => browser.Navigate("https://demo-sc.local/");
            btnSalir.Click += (s,e) => form.Close();

            topBar.Controls.Add(btnLocal);
            topBar.Controls.Add(btnExterno);
            topBar.Controls.Add(btnTest);
            topBar.Controls.Add(btnSalir);

            form.Controls.Add(browser);
            form.Controls.Add(topBar);

            Application.Run(form);
        }
    }
}
