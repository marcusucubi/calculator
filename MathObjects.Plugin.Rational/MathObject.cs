using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Rational
{
    class MathObject : IMathObject, IHasOutput, IHasDisplayValue 
    {
        readonly Tuple<int, int> value;

        public MathObject(Tuple<int, int> param)
        {
            value = param;
        }

        public object Output
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

                if (param is string)
                {
                    int paramValue;
                    int.TryParse(param as string, out paramValue);

                    tuple = new Tuple<int, int>(paramValue, 1);
                }

                return new MathObject(tuple);
            }

            public string[] PossibleParameters 
            { 
                get { return new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}; } 
            }
        }
    }
}

