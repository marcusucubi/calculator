using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    class PopOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "pop"; } }

        public override IMathObject Perform(IMathObject[] target)
        {
            var result = new PopObject(target[0]);

            result.CopyDecorations(target[0]);

            return result;
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

