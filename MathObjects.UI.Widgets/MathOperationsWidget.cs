using System;
using MathObjects.Framework;
using Gtk;
using MathObjects.UI.Mediator;
using MathObjects.Framework.Registry;

namespace MathObjects.UI.Widgets
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class MathOperationsWidget : Gtk.Bin
    {
        uint x;

        uint y;

        FactoryRegistry registry;

        IMediator mediator;

        public MathOperationsWidget()
        {
            this.Build();
        }

        public void Connect(FactoryRegistry registry, IMediator mediator)
        {
            this.registry = registry;
            this.mediator = mediator;

            SetupButtons();
        }

        public void Disconnect()
        {
            this.registry = null;
            this.mediator = null;

            this.x = this.y = 0;

            foreach (var c in this.table1.Children)
            {
                c.Visible = false;
                this.table1.Remove(c);
            }
        }

        void SetupButtons()
        {
            foreach (var key in this.registry.BinaryOperationDictionary.Keys)
            {
                var factory = this.registry.BinaryOperationDictionary[key];

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

        void AddButton(object key, IMathBinaryOperationFactory factory)
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
                    var op = factory.Create(null);

                    this.mediator.Perform(op);
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
                    var op = factory.Create(null);

                    this.mediator.Perform(op);
                };
        }
    }
}

