using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    abstract class Function : IMathFunction 
    {
        public virtual void Init(IMathFunctionContext context)
        {
        }

        public abstract IMathOperation Perform(IMathFunctionContext context);
    }
}

