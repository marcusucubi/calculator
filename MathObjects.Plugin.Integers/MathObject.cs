using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class MathObject : IMathObject, IHasValue, IHasOutput
    {
        readonly int value;

        public MathObject(string param)
        {
            value = int.Parse(param);
        }

        public int Value
        {
            get { return this.value; }
        }

        public object Output
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return "" + value;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new MathObject(context.InitObject as string);
            }

            public string[] PossibleParameters 
            { 
                get 
                { 
                    return new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; 
                }
            }
        }
    }
}

