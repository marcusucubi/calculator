using System;
using MathObjects.Framework;
using Gtk;
using MathObjects.UI.Mediator;

namespace MathObjects.UI.Widgets
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class MathObjetsWidget : Gtk.Bin
    {
        uint x;

        uint y;

        FactoryRegistry registry;

        IMediator mediator;

        public MathObjetsWidget()
        {
            this.Build();
        }

        public void Connect(FactoryRegistry registry, IMediator mediator)
        {
            this.registry = registry;
            this.mediator = mediator;

            SetupButtons();
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

        void AddButton(object key, IMathObjectFactory factory)
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
                    var obj = factory.Create(key);

                    this.mediator.InsertNumber(obj);
                };
        }
    }
}

