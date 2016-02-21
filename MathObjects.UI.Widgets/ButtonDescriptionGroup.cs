using System;
using System.Linq;
using System.Collections.Generic;

namespace TestUI
{
    public class ButtonDescriptionGroup
    {
        readonly string label;

        readonly List<ButtonDescription> list =
            new List<ButtonDescription>();

        public ButtonDescriptionGroup(string label)
        {
            this.label = label;
        }

        public string Label
        {
            get { return this.label; }
        }

        public void Add(ButtonDescription[] descs)
        {
            this.list.AddRange(descs);
        }

        public void Add(ButtonDescription desc)
        {
            this.list.Add(desc);
        }

        public ButtonDescription[] Descriptions
        {
            get { return list.ToArray(); }
        }
    }
}

