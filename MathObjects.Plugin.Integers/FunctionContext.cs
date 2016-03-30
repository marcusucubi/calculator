using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers
{
    public class FunctionContext : IMathOperationFactoryContext, IHasMathObjectStack
    {
        readonly IMathObjectStack stack;

        public FunctionContext(IMathObjectStack stack)
        {
            this.stack = stack;
        }

        public IMathObjectStack Stack 
        { 
            get { return stack; } 
        }
    }
}

