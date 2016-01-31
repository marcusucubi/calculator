using System;
using MathObjects.Framework;
using Gtk;
using MathObjects.Framework.Registry;
using MathObjects.UI.Stack;

namespace MathObjects.UI.Widgets
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class MathOperationsWidget : Gtk.Bin
    {
        uint x;

        uint y;

        FactoryRegistry registry;

        InputWidget inputWidget;

        public MathOperationsWidget()
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
            this.registry = null;
            this.inputWidget = null;

            this.x = this.y = 0;

            foreach (var c in this.table1.Children)
            {
                c.Visible = false;
                this.table1.Remove(c);
            }
        }

        void SetupButtons()
        {
            foreach (var key in this.registry.OperationDictionary.Keys)
            {
                var factory = this.registry.OperationDictionary[key];

                var meta = factory as IHasName;

                if (meta == null)
                {
                    continue;
                }

                AddButton(meta.Name, factory);

                x++;
                if (x > 2)
                {
                    y++;
                    x = 0;
                }
            }

            foreach (var key in this.registry.OperationDictionary.Keys)
            {
                var factory = this.registry.OperationDictionary[key];

                var meta = factory as IHasName;

                if (meta == null)
                {
                    continue;
                }

                AddButton2(meta.Name, factory);

                x++;
                if (x > 2)
                {
                    y++;
                    x = 0;
                }
            }
        }

        void AddButton(object key, IMathOperationFactory factory)
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
                    this.inputWidget.CalcDisplayAdd(key.ToString());
                };
        }

        void AddButton2(object key, IMathOperationFactory factory)
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
                    this.inputWidget.CalcDisplayAdd(key.ToString());
                };
        }
    }
}

