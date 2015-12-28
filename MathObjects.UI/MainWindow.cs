using System;
using Gtk;
using MathObjects.UI;
using MathObjects.Framework;
using MathObjects.Core.Plugin;
using MathObjects.UI.Mediator;

public partial class MainWindow: Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();

        var registry = MainClass.FactoryRegistry;

        var mediator = MediatorFactory.Create(registry);

        this.mathobjetswidget1.Connect(
            registry, mediator);

        this.mathoperationswidget1.Connect(
            registry, mediator);
        
        this.inputwidget1.Connect(mediator);
        this.stackwidget21.Connect(mediator);
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }
}
