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

            this.entry1.ModifyFont(FontDescription.FromString("Courier 16"));
        }

        public void Connect(IMediator mediator)
        {
            this.stackbuttonwidget1.Mediator = mediator;
            this.stackbuttonwidget1.InputWidget = this;
        }

        public void CalcDisplayAdd(string input)
        {
            this.entry1.Text += input;
        }

        public string CalcDisplay
        {
            get { return this.entry1.Text; }
            set { this.entry1.Text = value; }
        }
    }
}

