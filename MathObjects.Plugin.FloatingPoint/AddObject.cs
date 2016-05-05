using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "+")]
    class AddObject : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, IHasValue
    {
        readonly double tuple1;

        readonly double tuple2;

        public AddObject(double tuple1, double tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public IMathObject Output
        {
            get { return new MathObject(tuple1 + tuple2); }
        }

        public IMathValue Value 
        { 
            get { return new MathValue(tuple1 + tuple2); } 
        }

        public string DisplayValue 
        { 
            get { return this.Output.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

