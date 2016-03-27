using System;

namespace MathObjects.Framework.Parser
{
    public class UndefinedObject : AbstractMathObject, 
        ICanBeDefined, IHasDisplayValue, IHasValue
    {
        public bool IsDefinded 
        { 
            get { return false; } 
        }

        public string DisplayValue 
        { 
            get { return "Undefined"; } 
        }

        public IMathValue Value
        {
            get { return new ValueObject(); }
        }

        class ValueObject : AbstractMathObject, IMathValue 
        {
            public object Value 
            { 
                get { return new Object(); } 
            }

            public bool IsDefinded 
            { 
                get { return false; } 
            }
        }
    }
}

