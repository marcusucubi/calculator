using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.FoatingPoint;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    class MathObject : IMathObject, IHasOutput, IHasDisplayValue 
    {
        readonly double value;

        public MathObject(double param)
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
            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new MathObject(0);
            }

            public string[] PossibleParameters 
            { 
                get 
                { 
                    return new string[] 
                    {
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                        "top()", "pi()", 
                        "(", ")", 
                        "^", "+", "-", "*", "/"
                    }; 
                } 
            }
        }
    }
}

