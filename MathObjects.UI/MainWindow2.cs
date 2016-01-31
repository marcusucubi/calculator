using System;
using Gtk;
using MathObjects.Framework.Registry;
using MathObjects.UI.Mediator;
using MathObjects.Framework.Parser;

namespace MathObjects.UI
{
    public partial class MainWindow2 : Gtk.Window
    {
        IMediator mediator;

        public MainWindow2()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.fieldwidget1.Connect(MainClass.PluginRegistry);

            this.fieldwidget1.MathPluginChanged += (sender, e) => 
                {
                    var registry = e.Plugin.GetRegistry();
                    var parser = e.Plugin.GetParser();

                    Connect(registry, parser);
                };

            this.fieldwidget1.SelectFirst();
        }

        void Connect(FactoryRegistry registry, IParser parser) 
        {
            this.mediator = MediatorFactory.Create(registry, parser);

            this.mathobjetswidget2.Disconnect();
            this.mathobjetswidget2.Connect(
                registry, this.inputwidget1);

            this.stackwidget21.Disconnect();
            this.stackwidget21.Connect(mediator, this.inputwidget1);

            this.enterwidget1.Connect(mediator, this.inputwidget1);
        }

        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
            a.RetVal = true;
        }

        protected void OnKeyPressEvent (object sender, KeyPressEventArgs a)
        {
            if (a.Event.Key == Gdk.Key.Control_L)
            {
                if (this.inputwidget1.CalcDisplay.Length > 0)
                {
                    if (this.mediator.Enter(this.inputwidget1.CalcDisplay))
                    {
                        this.inputwidget1.CalcDisplay = "";
                    }
                }
            }
        }
    }
}

