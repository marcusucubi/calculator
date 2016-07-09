using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint2
{
    public class Data : AbstractMathObject, 
        IHasDisplayValue
    {
        readonly IMathObject[] objs;

        readonly string op;

        public Data(
            string op)
        {
            this.objs = new IMathObject[] {};
            this.op = op;
        }

        public Data(
            IMathObject[] objs, 
            string op)
        {
            this.objs = objs;
            this.op = op;
        }

        public IMathObject[] Children
        {
            get { return this.objs; }
        }

        public string DisplayValue 
        { 
            get { return "" + this.op; } 
        }
    }
}

