using System;
using Gdk;
using MathObjects.UI.Mediator;

namespace MathObjects.UI.Input
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        IMediator mediator;

        public InputWidget()
        {
            this.Build();

            this.entry1.WidgetEvent += OnEventbox1WidgetEvent;

            //this.entry1.Changed += OnEntry1Changed;

            //this.entry1.AddEvents((int)
            //    (EventMask.KeyPressMask));
        }

        public void Connect(IMediator mediator)
        {
            this.mediator = mediator;
            this.stackbuttonwidget1.Mediator = mediator;

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

        protected void OnEventbox1WidgetEvent (object o, Gtk.WidgetEventArgs args)
        {
            var keyEvent = args.Event as EventKey;
            if (keyEvent != null)
            {
                if (keyEvent.KeyValue == 65293)
                {
                    this.mediator.Enter();
                    this.entry1.Text = "";
                }
            }
        }

        protected void OnEntry1Changed (object sender, EventArgs e)
        {
            var s = this.entry1.Text;

            int i;
            if (int.TryParse(s, out i))
            {
                this.mediator.CurrentNumber = "" + i;
            }
            else if (s.Length != 0)
            {
                this.entry1.Text = "" + i;
            }
        }
    }
}

