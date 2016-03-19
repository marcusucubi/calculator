using System;
using System.Collections.Generic;
using Gtk;

namespace MathObjects.UI.Widgets
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class CoolExpanderList : VBox 
    {
        public event ChangedEventHandler Changed;

        int pos;

        int currentIndex;

        readonly List<CoolExpander> expanders = new List<CoolExpander>();

        public CoolExpanderList(ButtonDescriptionGroup[] groups)
        {
            foreach(var group in groups)
            {
                Add (group);
            }
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set 
            {
                if (value < this.expanders.Count && value >= 0) 
                {
                    this.currentIndex = value;
                    this.Open (this.currentIndex);

                    if (Changed != null)
                    {
                        Changed(this, new EventArgs());
                    }
                }
            }
        }

        CoolExpander Add(ButtonDescriptionGroup group)
        {
            var expander = new CoolExpander (group);

            expander.Activated += (sender, e) => 
                {
                    int i = this.expanders.IndexOf(expander); 
                    this.CloseOthers(i);
                    this.currentIndex = i;

                    if (Changed != null)
                    {
                        Changed(this, new EventArgs());
                    }
                };

            this.Add (expander);
            this.expanders.Add(expander);

            var child = (Box.BoxChild)(this[expander]);

            child.Position = ++pos;
            child.Expand = false;
            child.Fill = false;

            return expander;
        }

        void Open(int index)
        {
            for (int i = 0; i < this.expanders.Count; i++) 
            {
                if (i == index) 
                {
                    var e = expanders[i];
                    e.Expanded = true;
                }
            }

            CloseOthers (index);
        }

        void CloseOthers(int index)
        {
            for (int i = 0; i < this.expanders.Count; i++) 
            {
                if (i != index) 
                {
                    var e = expanders[i];

                    e.Expanded = false;
                }
            }
        }
    }
}

