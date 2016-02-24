using System;
using MathObjects.UI.Mediator;
using Pango;
using Gtk;

namespace MathObjects.UI.Stack
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        public InputWidget()
        {
            this.Build();

            this.textview1.ModifyFont(FontDescription.FromString("Courier 16"));
            this.button1.CanFocus = false;
        }

        public void CalcDisplayAdd(string input)
        {
            var buffer = this.textview1.Buffer;

            buffer.InsertAtCursor(input);
            this.textview1.HasFocus = true;

            if (input.Length > 0 && input.Substring(input.Length - 1) == ")")
            {
                var pos = buffer.CursorPosition - 1;
                var iter = buffer.GetIterAtOffset(pos);
                buffer.PlaceCursor(iter);
            }
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

        protected void OnButton1Clicked (object sender, EventArgs e)
        {
            var iter = this.textview1.Buffer.EndIter;
            this.textview1.Buffer.Backspace(ref iter, false, true);
        }
    }
}

