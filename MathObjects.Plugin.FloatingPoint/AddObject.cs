using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "+")]
    class AddObject : IHasOutput, IMathObject, IHasDisplayValue, ICanCopyByValue
    {
        readonly double tuple1;

        readonly double tuple2;

        public AddObject(double tuple1, double tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public object Output
        {
            get { return (tuple1 + tuple2); }
        }

        public string DisplayValue 
        { 
            get { return this.Output.ToString(); }
        }

        public IMathObject CopyByValue()
        {
            return this;
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

