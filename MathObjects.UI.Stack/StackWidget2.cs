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

            {
                var column = new Gtk.TreeViewColumn ();
                column.Title = "Value";
                
                var cell = new CellRendererText();
                column.PackStart(cell, true);
                column.AddAttribute(cell, "text", 0);
                this.treeview2.AppendColumn(column);
            }
            {
                var column = new Gtk.TreeViewColumn ();
                column.Title = "Source";

                var cell = new CellRendererText();
                column.PackStart(cell, true);
                column.AddAttribute(cell, "text", 1);
                this.treeview2.AppendColumn(column);
            }

            this.treeview2.HeadersVisible = true;

            store = new Gtk.TreeStore (typeof(string), typeof(string));

            this.treeview2.Model = store;

            this.treeview2.ModifyFont(FontDescription.FromString("Courier 16"));
        }

        public void Connect(
            IMediator mediator,
            InputWidget input)
        {
            this.mediator = mediator;

            this.mediator.StackChanged += (sender, e) => 
                {
                    DisplayNumbers(this.mediator.ObjectStack);
                };

            this.stackbuttonwidget1.Mediator = this.mediator;
            this.stackbuttonwidget1.InputWidget = input;
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
                string s = "";
                string s2 = "";

                var hasSource2 = i as IHasName;
                if (hasSource2 != null)
                {
                    s2 = hasSource2.Name;
                }

                var hasDisplay = i as IHasDisplayValue;
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

                        var hasSource = hasOutput.Output as IHasName;
                        if (hasSource != null)
                        {
                            s2 = hasSource.Name;
                        }
                    }
                    else
                    {
                        s = i.ToString();
                    }
                }

                TreeIter? iter;

                if (parent != null)
                {
                    iter = store.AppendValues(parent.Value, s, s2);
                }
                else
                {
                    iter = store.AppendValues(s, s2);
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

