using System;

namespace MathObjects.Framework.Parser
{
    public class ErrorObject : IMathObject, IHasDisplayValue, IIsError
    {
        readonly string error;

        public ErrorObject () 
        {
            error = "Error";
        }

        public ErrorObject (string error) 
        {
            this.error = error;
        }

        public string DisplayValue { get { return this.error; } }

        public string Description { get { return this.error; } }
    }
}

