using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    abstract class Function : AbstractMathObject, IMathOperationFactory2 
    {
        public virtual void Init(IMathOperationFactoryContext context)
        {
        }

        public abstract IMathOperation Perform(IMathOperationFactoryContext context);
    }
}

