using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    abstract class Function : IMathFunction 
    {
        public virtual void Init(IMathFunctionContext context)
        {
        }

        public abstract IMathObject Perform(IMathFunctionContext context);
        //{
        //    return new FunctionObject(InternalGetResult(context));
       // }

        protected abstract IMathObject InternalGetResult(IMathFunctionContext context);
    }
}

