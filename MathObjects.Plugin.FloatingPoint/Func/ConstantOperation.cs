using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantOperation : AbstractMathOperation
    {
        readonly double value;

        public override int NumberOfParameters { get { return 0; } }

        public override string Symbol { get { return "const"; } }

        public ConstantOperation(double value)
        {
            this.value = value;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            var result = new ConstantObject(value);

            result.CopyDecorations(this);

            return result;
        }

        public class Factory : AbstractMathObject, IMathOperationFactory2
        {
            readonly double value;

            public Factory(double value)
            {
                this.value = value;
            }

            public void Init(IMathOperationFactoryContext context)
            {
            }

            public IMathOperation Perform(IMathOperationFactoryContext context)
            {
                return new ConstantOperation(this.value);
            }

            public class Factory2 : IMathObjectFactory
            {
                readonly double value;

                public Factory2(double value)
                {
                    this.value = value;
                }

                public IMathObject Create(IMathObjectFactoryContext context)
                {
                    return new ConstantOperation.Factory(this.value);
                }
            }
        }
    }
}

