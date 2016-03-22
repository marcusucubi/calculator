using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    abstract class Function : AbstractMathObject, IMathFunction 
    {
        public virtual void Init(IMathFunctionContext context)
        {
        }

        public abstract IMathOperation Perform(IMathFunctionContext context);
    }
}

