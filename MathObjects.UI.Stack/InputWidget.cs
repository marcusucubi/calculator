using System;
using MathObjects.UI.Mediator;
using Pango;

namespace MathObjects.UI.Stack
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        public InputWidget()
        {
            this.Build();

            this.textview1.ModifyFont(FontDescription.FromString("Courier 16"));
        }

        public void CalcDisplayAdd(string input)
        {
            this.textview1.Buffer.InsertAtCursor(input);
            this.textview1.HasFocus = true;
        }

        public string CalcDisplay
        {
            get { return this.textview1.Buffer.Text; }
            set 
            { 
                this.textview1.Buffer.Clear(); 
                this.textview1.Buffer.InsertAtCursor(value);
            }
        }
    }
}

