using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopOperation : AbstractMathOperation
    {
        readonly IMathObject top;

        public override int NumberOfParameters { get { return 0; } }

        public override string Symbol { get { return "top"; } }

        public TopOperation(IMathObjectStack stack, IMathObject top)
        {
            this.top = top;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            if (top is IIsError)
            {
                return top;
            }

            return new TopObject(top);
        }
    }
}

