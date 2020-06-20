using System;
using Converting;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace BinaryConverter
{
    class MainWindow : Window
    {
        [UI] public Label Instructions = null;
        [UI] public Label WindowTitle = null;
        [UI] public Button ConvertToBinary = null;
        [UI] public Entry IntelligibleInput = null;
        [UI] public Button ConvertToText = null;
        [UI] public Button SubmitText = null;
        [UI] public Button SubmitBinary = null;
        [UI] public Entry BinaryInput = null;
        [UI] public Button BackButton = null;
        private static Gdk.Atom atom = Gdk.Atom.Intern("CLIPBOARD", false);
        private Gtk.Clipboard cb = Gtk.Clipboard.Get(atom);

        private Object[] Items() => new Object[] 
        {
            Instructions,
            WindowTitle,
            ConvertToBinary,
            IntelligibleInput,
            ConvertToText,
            SubmitText,
            BackButton,
            SubmitBinary,
            BinaryInput
        };
        private Object[] BinaryScreen() => new Object[]
        {
            IntelligibleInput,
            SubmitText
        };
        private Object[] TextScreen() => new Object[]
        {
            BinaryInput,
            SubmitBinary
        };
        private Object[] HideAtStart() => new Object[]
        {
            IntelligibleInput,
            SubmitText,
            BackButton,
            BinaryInput,
            SubmitBinary
        };
        // Window initialization
        public MainWindow() : this(new Builder("MainWindow.glade")) { }
        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            CssProvider css = new CssProvider();
            Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css, StyleProviderPriority.Application);
            css.LoadFromPath("./css/WindowStyle.css");
            builder.Autoconnect(this);
            // Hide all items that will be used later in usage
            foreach (dynamic item in HideAtStart())
                item.Hide();
            // Events
            DeleteEvent += Window_DeleteEvent;
            ConvertToBinary.Clicked += StartBinary;
            ConvertToText.Clicked += StartText;
            SubmitText.Clicked += ConvertedText;
            IntelligibleInput.Activated += ConvertedText;
            BackButton.Clicked += HomePage;
            SubmitBinary.Clicked += ConvertedBinary;
            BinaryInput.Activated += ConvertedBinary;
        }
        // events
        Binary BinaryConverter = new Binary();
        Intelligible BinaryTranslator = new Intelligible();
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
        private void ClearPage()
        {
            foreach (dynamic item in Items())
                item.Hide();
        }
        private void ToBinary()
        {
            foreach (dynamic item in BinaryScreen())
                item.Show();
            Instructions.Text = "Insert the text that you want to be converted to binary.";
            Instructions.Show();
        }
        private void ToText()
        {
            foreach (dynamic item in TextScreen())
                item.Show();
            Instructions.Text = "Insert the binary that you want to be converted to text.";
            Instructions.Show();
        }
        private void StartBinary(object sender, EventArgs a)
		{
			ClearPage();
            ToBinary();
		}
        private void StartText(object sender, EventArgs a)
		{
			ClearPage();
            ToText();
		}
        private void ConvertedText(object sender, EventArgs a)
		{
			ClearPage();
            WindowTitle.Text = "Result";
            Instructions.Text = BinaryConverter.Convert(IntelligibleInput.Text) + "\n(Copied to clipboard)";
            WindowTitle.Show();
            Instructions.Show();
            BackButton.Show();
            cb.Text = Instructions.Text.Substring(0, Instructions.Text.Length - 22);
            IntelligibleInput.Text = "";
		}
        private void ConvertedBinary(object sender, EventArgs a)
		{
			ClearPage();
            WindowTitle.Text = "Result";
            Instructions.Text = BinaryTranslator.Translate(BinaryInput.Text) + "\n(Copied to clipboard)";
            WindowTitle.Show();
            Instructions.Show();
            BackButton.Show();
            cb.Text = Instructions.Text.Substring(0, Instructions.Text.Length - 22);
            BinaryInput.Text = "";
		}
        private void HomePage(object sender, EventArgs a)
        {
            ClearPage();
            WindowTitle.Text = "Binary Converter";
            Instructions.Text = "Convert binary characters to English, or inversely convert English characters to binary. The result of the conversion will be copied to your clipboard.";
            WindowTitle.Show();
            Instructions.Show();
            ConvertToText.Show();
            ConvertToBinary.Show();
        }
    }
}
