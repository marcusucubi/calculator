using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class PopOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "pop"; } }

        public override IMathObject Perform(IMathObject[] target)
        {
            return new PopObject(target[0]);
        }

        public class Factory : AbstractMathObject, IMathOperationFactory2
        {
            public void Init(IMathOperationFactoryContext context)
            {
            }

            public IMathOperation Perform(IMathOperationFactoryContext context)
            {
                return new PopOperation();
            }
        }
    }
}

