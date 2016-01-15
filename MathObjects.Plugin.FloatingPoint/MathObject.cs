using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    class MathObject : IMathObject, IHasDouble, IHasDisplayValue 
    {
        readonly double value;

        public MathObject(double param)
        {
            value = param;
        }

        public double Double
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
            public IMathObject Create(string param)
            {
                double tuple = 0;

                if (param is string)
                {
                    double temp;

                    if (double.TryParse(param, out temp))
                    {
                        tuple = temp;
                    }
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

