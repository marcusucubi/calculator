using System;

namespace MathObjects.Framework.Parser
{
    public class MathObjectStackArgs : EventArgs 
    {
        public IMathObjectStack Stack
        {
            get;
            set;
        }
    }
}

