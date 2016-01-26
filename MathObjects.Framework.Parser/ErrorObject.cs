using System;

namespace MathObjects.Framework.Parser
{
    public class ErrorObject : IMathObject, IHasDisplayValue 
    {
        public ErrorObject () 
        {
        }

        public string DisplayValue { get { return "Error"; } }
    }
}

