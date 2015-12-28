using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    class MathObject : IMathObject, IHasTuple, IHasDisplayValue 
    {
        readonly Tuple<int, int> value;

        public MathObject(Tuple<int, int> param)
        {
            value = param;
        }

        public Tuple<int, int> Tuple
        {
            get { return this.value; }
        }

        public string DisplayValue 
        { 
            get { return this.value.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(object param)
            {
                Tuple<int, int> tuple = new Tuple<int, int>(1, 1);

                if (param is int)
                {
                    tuple = new Tuple<int, int>((int)param, 1);
                }

                return new MathObject(tuple);
            }

            public object[] PossibleParameters 
            { 
                get { return new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}; } 
            }
        }
    }
}

