using System;
using Gtk;
using MathObjects.UI;
using MathObjects.Framework;
using MathObjects.Core.Plugin;
using MathObjects.UI.Mediator;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

public partial class MainWindow: Gtk.Window
{
    IMediator mediator;

    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build();

        this.fieldwidget1.Connect(MainClass.PluginRegistry);

        this.fieldwidget1.MathPluginChanged += (sender, e) => 
            {
                var registry = MainClass.PluginRegistry.Plugins[e.Plugin];

                var hasParser = e.Plugin as IHasParser;

                if (hasParser != null)
                {
                    Connect(registry, hasParser.Parser);
                }
                else
                {
                    Connect(registry, null);
                }
            };

        this.fieldwidget1.SelectFirst();
    }

    void Connect(
        FactoryRegistry registry,
        IParser parser) 
    {
        this.mediator = MediatorFactory.Create(registry, parser);

        this.mathobjetswidget1.Disconnect();
        this.mathobjetswidget1.Connect(
            registry, mediator, parser);

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
