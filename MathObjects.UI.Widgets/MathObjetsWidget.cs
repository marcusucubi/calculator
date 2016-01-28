using System;
using MathObjects.Framework;
using Gtk;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.UI.Stack;

namespace MathObjects.UI.Widgets
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class MathObjetsWidget : Gtk.Bin
    {
        uint x;

        uint y;

        FactoryRegistry registry;

        InputWidget inputWidget;

        public MathObjetsWidget()
        {
            this.Build();
        }

        public void Connect(
            FactoryRegistry registry, 
            InputWidget inputWidget)
        {
            this.registry = registry;
            this.inputWidget = inputWidget;

            SetupButtons();
        }

        public void Disconnect()
        {
            x = y = 0;

            this.registry = null;
            this.inputWidget = null;

            foreach (var c in this.table1.Children)
            {
                c.Visible = false;
                this.table1.Remove(c);
            }
        }

        void SetupButtons()
        {
            foreach (var key in this.registry.ObjectDictionary.Keys)
            {
                var factory = this.registry.ObjectDictionary[key];

                var meta = factory as IMathObjectMeta;

                if (meta == null)
                {
                    continue;
                }

                foreach(var param in meta.PossibleParameters)
                {
                    AddButton(param, factory);

                    x++;
                    if (x > 2)
                    {
                        y++;
                        x = 0;
                    }
                }
            }
        }

        void AddButton(string key, IMathObjectFactory factory)
        {
            var button1 = new Button();
            button1.CanFocus = true;
            button1.Name = "button" + key;
            button1.UseUnderline = true;
            button1.Label = "" + key;

            this.table1.Attach(button1, x, x+1, y, y+1);

            button1.Show();

            button1.Clicked += (sender, e) =>
            {
                inputWidget.CalcDisplayAdd(key);
                /*
                if (this.parser != null)
                {
                    parser.Parse(key, this.mediator);
                }
                else 
                {
                    var context = new FactoryContext();
                    context.InitObject = key;
                    var obj = factory.Create(context);
                        
                    this.mediator.InsertNumber(obj);
                }
                */
            };
        }
    }
}

