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

            var app = new Application("org.BinaryConverter.BinaryConverter", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            win.Title = "Binary Converter";
            
            Application.Run();
        }
    }
}
