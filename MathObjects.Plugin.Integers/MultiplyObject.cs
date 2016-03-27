using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers
{
    [ClassDecoration("name", "*")]
    class MultiplyObject : AbstractMathObject, IHasOutput, IHasValue
    {
        readonly int tuple1;

        readonly int tuple2;

        public MultiplyObject(int tuple1, int tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public IMathObject Output
        {
            get { return new MathObject(tuple1 * tuple2); }
        }

        public IMathValue Value 
        { 
            get { return new MathValue(tuple1 * tuple2); } 
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

