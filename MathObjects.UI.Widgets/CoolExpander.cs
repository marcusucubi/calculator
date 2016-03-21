using System;
using Gtk;
using System.Collections.Generic;

namespace MathObjects.UI.Widgets
{
    public class CoolExpander : Expander
    {
        int pos;

        int buttonPos;

        public CoolExpander (ButtonDescriptionGroup group)
            : base(group.Label)
        {
            var vbox = new VBox();
            this.Add(vbox);
            vbox.Spacing = 6;

            var stack = new List<ButtonDescription>(group.Descriptions);

            while(stack.Count > 0)
            {
                var box = CreateButtonBox(vbox);

                for(int x = 0; x < 6 && stack.Count > 0; x++)
                {
                    var desc = stack[0];
                    stack.RemoveAt (0);

                    var b = CreateButton(desc);

                    AddButton(box, b);
                }
            }
        }

        HButtonBox CreateButtonBox(VBox vbox)
        {
            var box = new HButtonBox ();

            vbox.Add(box);
            var child = (Box.BoxChild) vbox[box];
            child.Position = ++pos;
            child.Expand = false;
            child.Fill = false;

            return box;
        }

        void AddButton(HButtonBox box, Button b)
        {
            box.Add (b);

            var w2 = (ButtonBox.ButtonBoxChild) box [b];

            w2.Position = ++buttonPos;
            w2.Expand = false;
            w2.Fill = false;
        }

        Button CreateButton(ButtonDescription desc)
        {
            var b = new Button();
            b.CanFocus = true;
            b.Name = "button89";
            b.UseUnderline = true;
            b.Label = desc.Label;

            b.Clicked += desc.Handler;

            return b;
        }

        protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
        {
            return base.OnButtonPressEvent(evnt);
        }
    }
}

