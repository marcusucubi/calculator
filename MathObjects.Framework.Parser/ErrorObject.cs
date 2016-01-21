using System;

namespace MathObjects.Framework.Parser
{
    public class ErrorObject : IMathObject, IHasDisplayValue 
    {
        public string DisplayValue { get { return "Error"; } }
    }
}

