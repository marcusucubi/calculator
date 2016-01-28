using System;
using System.Collections.Generic;
using Gtk;
using Pango;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.UI.Mediator;

namespace MathObjects.UI.Stack
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class StackWidget2 : Gtk.Bin 
    {
        IMediator mediator;

        TreeStore store;

        public StackWidget2()
        {
            this.Build();

            var column = new Gtk.TreeViewColumn ();
            column.Title = "Value";

            var cell = new CellRendererText();

            column.PackStart (cell, true);
            column.AddAttribute (cell, "text", 0);
            this.treeview2.AppendColumn (column);
            this.treeview2.HeadersVisible = false;

            store = new Gtk.TreeStore (typeof (string));

            this.treeview2.Model = store;

            this.treeview2.ModifyFont(FontDescription.FromString("Courier 16"));
        }

        public void Connect(IMediator mediator)
        {
            this.mediator = mediator;

            this.mediator.StackChanged += (sender, e) => 
                {
                    DisplayNumbers(this.mediator.ObjectStack);
                };
        }

        public void Disconnect()
        {
            this.store.Clear();
        }

        public void DisplayNumbers(IEnumerable<IMathObject> numbers)
        {
            store.Clear();

            DisplayChildren(null, numbers);
        }

        public void DisplayChildren(
            TreeIter? parent,
            IEnumerable<IMathObject> numbers)
        {
            foreach(var i in numbers)
            {
                var hasDisplay = i as IHasDisplayValue;

                string s = "";
                if (hasDisplay != null)
                {
                    s = hasDisplay.DisplayValue;
                }
                else
                {
                    var hasOutput = i as IHasOutput;

                    if (hasOutput != null)
                    {
                        s = "" + hasOutput.Output;
                    }
                    else
                    {
                        s = i.ToString();
                    }
                }

                TreeIter? iter;

                if (parent != null)
                {
                    iter = store.AppendValues(parent.Value, s);
                }
                else
                {
                    iter = store.AppendValues(s);
                }

                var children = i as IHasChildren;
                if (children != null)
                {
                    DisplayChildren(iter, children.Children);
                }
            }
        }
    }
}

