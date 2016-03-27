using System;

namespace MathObjects.Framework.Parser
{
    public class UndefinedObject : AbstractMathObject, ICanBeDefined, IHasDisplayValue  
    {
        public bool IsDefinded 
        { 
            get { return false; } 
        }

        public string DisplayValue 
        { 
            get { return "Undefined"; } 
        }
    }
}

