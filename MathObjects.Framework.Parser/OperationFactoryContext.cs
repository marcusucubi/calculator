using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Framework.Parser
{
    public class OperationFactoryContext : 
        IMathOperationFactoryContext, IHasMathObjectStack
    {
        readonly IMathObjectStack stack;

        public OperationFactoryContext(IMathObjectStack stack)
        {
            this.stack = stack;
        }

        public IMathObjectStack Stack 
        { 
            get { return stack; } 
        }
    }
}


