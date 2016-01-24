using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopOperation : IMathOperation
    {
        readonly IMathObject top;

        public TopOperation(IMathObjectStack stack, IMathObject top)
        {
            this.top = top;
        }

        public IMathObject Perform(IMathObject target)
        {
            return new TopObject(top);
        }
    }
}

