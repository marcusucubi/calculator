using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopOperation : IMathOperation
    {
        readonly IMathObject top;

        public int NumberOfParameters { get { return 0; } }

        public TopOperation(IMathObjectStack stack, IMathObject top)
        {
            this.top = top;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            if (top is IIsError)
            {
                return top;
            }

            return new TopObject(top);
        }
    }
}

