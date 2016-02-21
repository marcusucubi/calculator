using System;
using Gtk;

namespace TestUI
{
    public class ButtonDescription
    {
        readonly EventHandler handler;

        readonly string label;

        public ButtonDescription(string label, EventHandler handler)
        {
            this.handler = handler;
            this.label = label;
        }

        public EventHandler Handler
        {
            get { return this.handler; }
        }

        public string Label
        {
            get { return this.label; }
        }
    }
}

