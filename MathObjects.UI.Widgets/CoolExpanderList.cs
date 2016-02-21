using System;
using System.Collections.Generic;
using Gtk;

namespace TestUI
{
    public class CoolExpanderList : VBox 
    {
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

