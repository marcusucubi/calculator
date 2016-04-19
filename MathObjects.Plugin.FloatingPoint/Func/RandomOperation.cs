using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    class RandomOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "random"; } }

        public RandomOperation()
        {
        }
      
        public override IMathObject Perform(IMathObject[] target)
        {
            var input = target[0].GetDouble();

            var value = new Random().Next((int) input);

            var result = new RandomObject(value);

            result.CopyDecorations(this);

            return result;
        }

        public class Factory : AbstractMathObject, IMathOperationFactory2
        {
            public Factory()
            {
            }

            public void Init(
                IMathOperationFactoryContext context)
            {
            }

            public IMathOperation Perform(
                IMathOperationFactoryContext context)
            {
                return new RandomOperation();
            }

            public class Factory2 : IMathObjectFactory
            {
                public Factory2()
                {
                }

                public IMathObject Create(
                    IMathObjectFactoryContext context)
                {
                    return new RandomOperation.Factory();
                }
            }
        }
    }
}

