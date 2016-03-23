using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    abstract class Function : AbstractMathObject, IMathOperationFactory2 
    {
        public virtual void Init(IMathFunctionContext context)
        {
        }

        public abstract IMathOperation Perform(IMathFunctionContext context);
    }
}

