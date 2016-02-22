using System;
using System.Collections.Generic;
using Gdk;
using Gtk;
using MathObjects.Core.Plugin;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Vocabulary;
using MathObjects.UI.Mediator;
using MathObjects.UI.Stack;
using MathObjects.UI.Widgets;
using MathObjects.Framework.Parser;

namespace MathObjects.UI
{
    public partial class MainWindow2 : Gtk.Window
    {
        IMediator mediator;

        SliderWidget2 keyboardwidget1;

        public MainWindow2()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.fieldwidget1.Connect(MainClass.PluginRegistry);

            this.fieldwidget1.MathPluginChanged += (sender, e) => 
                {
                    var registry = e.Plugin.GetRegistry();
                    var parser = e.Plugin.GetParser();

                    Connect(registry, parser, e.Plugin);
                };

            this.fieldwidget1.SelectFirst();
        }

        void Connect(FactoryRegistry registry, IParser parser, IPlugin plugin) 
        {
            this.mediator = MediatorFactory.Create(registry, parser);

            AddKeyboard(this.inputwidget1, plugin);

            this.stackwidget21.Disconnect();
            this.stackwidget21.Connect(mediator, this.inputwidget1);

            this.enterwidget1.Connect(mediator, this.inputwidget1);
        }

        void AddKeyboard(InputWidget input, IPlugin plugin)
        {
            if (keyboardwidget1 != null)
            {
                keyboardwidget1.Hide();
                this.table1.Remove(keyboardwidget1);
            }

            var groups = CreateGroups(input, plugin);
            keyboardwidget1 = new SliderWidget2(groups);

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

        ButtonDescriptionGroup[] CreateGroups(InputWidget input, IPlugin plugin)
        {
            var groups = new List<ButtonDescriptionGroup> ();

            var vocab = plugin as IHasVocabulary;
            if (vocab != null)
            {
                foreach (var g in vocab.WordGroups)
                {
                    var group = new ButtonDescriptionGroup(g.Name);

                    foreach (var w in g.Words)
                    {
                        group.Add(new StandardButtonDescription(w.Data, this.inputwidget1));
                    }

                    groups.Add(group);
                }
            }

            /*
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
            */

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

