using System;

namespace TestUI
{
    public partial class TestWindow : Gtk.Window
    {
        public TestWindow () :
            base (Gtk.WindowType.Toplevel)
        {
            this.Build ();
        }
    }
}

