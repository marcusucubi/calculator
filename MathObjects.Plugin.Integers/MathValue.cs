using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class MathValue : AbstractMathObject, IMathValue
    {
        int value;

        public MathValue(int value)
        {
            this.value = value;
        }

        public object Value
        {
            get { return this.value; }
        }

        public bool IsDefinded 
        { 
            get { return true; } 
        }
    }
}

