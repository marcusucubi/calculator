using System;
using Gtk;
using MathObjects.Framework.Registry;
using MathObjects.UI.Mediator;
using MathObjects.Framework.Parser;
using MathObjects.UI.Widgets;
using Gdk;
using System.Collections.Generic;
using MathObjects.UI.Stack;

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

            AddKeyboard(this.inputwidget1);

            //this.mathobjetswidget2.Disconnect();
            //this.mathobjetswidget2.Connect(
            //    registry, this.inputwidget1);

            this.stackwidget21.Disconnect();
            this.stackwidget21.Connect(mediator, this.inputwidget1);

            this.enterwidget1.Connect(mediator, this.inputwidget1);
        }

        void AddKeyboard(InputWidget input)
        {
            var groups = CreateGroups(input);
            var keyboardwidget1 = new SliderWidget2(groups);

            keyboardwidget1.HeightRequest = 250;
            keyboardwidget1.Events = ((EventMask)(256));
            keyboardwidget1.Name = "keyboardwidget1";
            keyboardwidget1.HeightRequest = 250;
            table1.Add (keyboardwidget1);

            var w5 = ((Table.TableChild)(this.table1 [keyboardwidget1]));

            w5.TopAttach = ((uint)(4));
            w5.BottomAttach = ((uint)(5));
            w5.XOptions = ((AttachOptions)(4));
            w5.YOptions = ((AttachOptions)(4));
        }

        ButtonDescriptionGroup[] CreateGroups(InputWidget input)
        {
            var groups = new List<ButtonDescriptionGroup> ();

            {
                var group = new ButtonDescriptionGroup ("Standard");

                for (int i = 0; i < 9; i++) 
                {
                    string key = "" + (i + 1);
                    group.Add (new StandardButtonDescription (key, this.inputwidget1) );
                }

                group.Add (new StandardButtonDescription ("+", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("*", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("-", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("/", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("^", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("(", this.inputwidget1) );
                group.Add (new StandardButtonDescription (")", this.inputwidget1) );
                groups.Add (group);
            }

            {
                var group = new ButtonDescriptionGroup ("Triganometry");
                group.Add (new StandardButtonDescription ("sin()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("cos()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("tan()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("asin()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("acos()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("atan()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("pi()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("degrees()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("radians()", this.inputwidget1) );
                groups.Add (group);
            }

            {
                var group = new ButtonDescriptionGroup ("Logarithm");
                group.Add (new StandardButtonDescription ("exp()", this.inputwidget1) );
                group.Add (new StandardButtonDescription ("log()", this.inputwidget1) );
                groups.Add (group);
            }

            return groups.ToArray ();
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

