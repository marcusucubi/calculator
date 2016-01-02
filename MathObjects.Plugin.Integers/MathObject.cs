using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class MathObject : IMathObject, IHasValue
    {
        readonly int value;

        public MathObject(object param)
        {
            value = (int)param;
        }

        public int Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return "" + value;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(object param)
            {
                return new MathObject(param);
            }

            public object[] PossibleParameters 
            { 
                get { return new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}; } 
            }
        }
    }
}

