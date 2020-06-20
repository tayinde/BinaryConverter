using System;
using Gtk;

namespace BinaryConverter
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            Application app = new Application("org.BinaryConverter.BinaryConverter", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            Window win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            win.Title = "Binary Converter";
            
            Application.Run();
        }
    }
}
