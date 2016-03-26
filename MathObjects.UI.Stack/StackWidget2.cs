using System;
using System.Collections.Generic;
using System.Diagnostics;
using Gtk;
using Pango;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.UI.Mediator;
using MathObjects.Core.DecoratableObject;
using MathObjects.Core.Extension;

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

            this.treeview2.CanFocus = false;
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
                Debug.Assert(i != null);
                if (i == null)
                {
                    throw new Exception();
                }

                string s = "";
                string s2 = GetName(i);

                var hasDisplay = i as IHasDisplayValue;
                if (hasDisplay != null)
                {
                    s = hasDisplay.DisplayValue;
                }
                else
                {
                    var hasValue = i as IHasValue;

                    if (hasValue != null)
                    {
                        s = "" + hasValue.Value;

                        if (s2.Length == 0)
                        {
                            s2 = GetName(hasValue.Value);
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

        string GetName(object obj)
        {
            string result = "";

            var test = GetDecoration(obj);
            if (test != null)
            {
                result = test;
            }
            else
            {
                var output = obj as IHasOutput;
                if (output != null)
                {
                    var test2 = GetDecoration(output.Output);
                    if (test2 != null)
                    {
                        result = test2;
                    }
                }
            }

            return result;
        }

        string GetDecoration(object obj)
        {
            var test = obj.GetClassDecoration<string>("name");
            if (test != null)
            {
                return test;
            }

            var ext = obj as IExtensionableObject;
            if (ext != null)
            {
                var test2 = ext.GetObjectDecoration<string>("name");
                if (test2 != null)
                {
                    return test2;
                }
            }

            return null;
        }
    }
}

