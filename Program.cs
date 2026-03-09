using System;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();

        Form form = new Form();
        form.Width = 1200;
        form.Height = 800;

        WebBrowser browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.Navigate("https://lim-sc01/owa");

        form.Controls.Add(browser);
        Application.Run(form);
    }
}
