using System;
using Gdk;
using MathObjects.UI.Mediator;
using Pango;

namespace MathObjects.UI.Input
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        IMediator mediator;

        public InputWidget()
        {
            this.Build();

            this.entry1.ModifyFont(FontDescription.FromString("Courier 16"));
        }

        public void Connect(IMediator mediator)
        {
            this.mediator = mediator;
            this.stackbuttonwidget1.Mediator = mediator;

            this.entry1.Changed += (sender, e) => 
                {
                    this.mediator.CurrentNumber = this.entry1.Text;
                };

            this.mediator.CurrentNumberChaned += (sender, e) => 
                { 
                    if (this.mediator.CurrentNumber == "")
                    {
                        this.entry1.Text = ""; 
                    }
                    else
                    {
                        this.entry1.Text = "" + this.mediator.CurrentNumber; 
                    }
                };
        }

        public string CalcDisplay
        {
            get { return this.entry1.Text ; }
        }
    }
}

