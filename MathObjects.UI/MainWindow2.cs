using System;
using Gtk;
using MathObjects.Framework.Registry;
using MathObjects.UI.Mediator;

namespace MathObjects.UI
{
    public partial class MainWindow2 : Gtk.Window
    {
        public MainWindow2()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.fieldwidget1.Connect(MainClass.PluginRegistry);

            this.fieldwidget1.MathPluginChanged += (sender, e) => 
                {
                    var registry = MainClass.PluginRegistry.Plugins[e.Plugin];

                    Connect(registry);
                };

            this.fieldwidget1.SelectFirst();
        }

        void Connect(FactoryRegistry registry) 
        {
            var mediator = MediatorFactory.Create(registry);

            this.mathobjetswidget2.Disconnect();
            this.mathobjetswidget2.Connect(
                registry, mediator);

            this.mathoperationswidget1.Disconnect();
            this.mathoperationswidget1.Connect(
                registry, mediator);

            this.inputwidget1.Connect(mediator);

            this.stackwidget21.Disconnect();
            this.stackwidget21.Connect(mediator);
        }

        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
            a.RetVal = true;
        }
    }
}

