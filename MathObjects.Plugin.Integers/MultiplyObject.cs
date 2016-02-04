using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers
{
    [ClassDecoration("name", "*")]
    class MultiplyObject : IHasOutput, IMathObject, IHasValue
    {
        readonly int tuple1;

        readonly int tuple2;

        public MultiplyObject(int tuple1, int tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public object Output
        {
            get { return (tuple1 * tuple2); }
        }

        public int Value
        {
            get { return (int)Output; }
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

