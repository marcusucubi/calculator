using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class MathObject : AbstractMathObject, IHasValue, IHasOutput
    {
        readonly int value;

        public MathObject(int param)
        {
            value = param;
        }

        public IMathValue Value 
        { 
            get { return new MathValue(value); } 
        }

        public IMathObject Output
        {
            get { return new MathValue(this.value); }
        }

        public override string ToString()
        {
            return "" + value;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new MathObject((int)context.InitObject);
            }

            public string[] PossibleParameters 
            { 
                get 
                { 
                    return new string[] 
                    {
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                        "(", ")", 
                        "^", "+", "-", "*"
                    }; 
                }
            }
        }
    }
}

