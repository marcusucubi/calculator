using System;
using MathObjects.UI.Widgets;
using MathObjects.UI.Stack;

namespace MathObjects.UI
{
    public class StandardButtonDescription : ButtonDescription
    {
        public StandardButtonDescription(string label, InputWidget input) :
        base(label, (x, y) => { input.CalcDisplayAdd(label); } )
        {
        }
    }
}

