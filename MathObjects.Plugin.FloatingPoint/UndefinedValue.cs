using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class UndefinedValue : AbstractMathObject, IMathValue
    {
        public object Value
        {
            get { return 0d; }
        }

        public bool IsDefinded 
        { 
            get { return false; } 
        }

        public override string ToString()
        {
            return "undefined value";
        }
    }
}

