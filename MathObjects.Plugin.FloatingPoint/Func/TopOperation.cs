using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopOperation : AbstractMathOperation
    {
        readonly IMathObjectStack stack;

        public override int NumberOfParameters { get { return 0; } }

        public override string Symbol { get { return "top"; } }

        public TopOperation(IMathObjectStack stack)
        {
            this.stack = stack;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            if (stack.Top is IIsError)
            {
                return stack.Top;
            }

            return new TopObject(this.stack);
        }

        public class Factory : AbstractMathObject, IMathOperationFactory2
        {
            IMathObjectStack stack;

            public void Init(IMathOperationFactoryContext context)
            {
                stack = (context as IHasMathObjectStack).Stack;
            }

            public IMathOperation Perform(IMathOperationFactoryContext context)
            {
                return new TopOperation(stack);
            }
        }
    }
}
