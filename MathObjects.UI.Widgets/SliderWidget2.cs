using System;
using System.ComponentModel;
using Gtk;

namespace MathObjects.UI.Widgets
{
    [ToolboxItem(true)]
    public class SliderWidget2 : Gtk.HBox 
    {
        ButtonDescriptionGroup[] groups;

        CoolExpanderList cool;

        HBox hbox1;

        Button b1, b2;

        public SliderWidget2()
        {
            this.SetSizeRequest (300, 150);
        }

        public SliderWidget2(ButtonDescriptionGroup[] groups)
        {
            Setup(groups);

            this.SetSizeRequest (300, 150);
        }

        void Setup(ButtonDescriptionGroup[] groups)
        {
            this.groups = groups;
            this.hbox1 = this;
            this.hbox1.Spacing = 6;

            b1 = AddButton("<<", 0);
            b1.Clicked += (sender, e) => 
                {
                    this.cool.CurrentIndex--;
                };

            cool = new CoolExpanderList (groups);

            this.hbox1.Add(cool);
            var w1 = (Box.BoxChild)(this.hbox1[cool]);
            w1.Position = 1;

            b2 = AddButton(">>", 2);
            b2.Clicked += (sender, e) => 
                {
                    this.cool.CurrentIndex++;
                };

            this.cool.CurrentIndex = 0;
            UpdateState();

            cool.Changed += (sender, e) => 
                {
                    UpdateState();
                };

            this.ShowAll ();
        }

        void UpdateState()
        {
            if (cool.CurrentIndex == 0)
            {
                b1.Sensitive = false;
            }
            else
            {
                b1.Sensitive = true;
            }

            if (cool.CurrentIndex == this.groups.Length - 1)
            {
                b2.Sensitive = false;
            }
            else
            {
                b2.Sensitive = true;
            }
        }

        Button AddButton(string label, int position)
        {
            var b = new Button();

            b.CanFocus = true;
            b.UseUnderline = true;
            b.Label = label;
            b.CanFocus = false;
            this.hbox1.Add(b);

            var w1 = (Box.BoxChild)(this.hbox1[b]);
            w1.Position = position;
            w1.Expand = false;
            w1.Fill = false;

            return b;
        }
    }
}

