using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopOperation : IMathOperation
    {
        readonly IMathObject top;

        public TopOperation(IMathObject top)
        {
            this.top = top;
        }

        public IMathObject Perform(IMathObject target)
        {
            return new TopObject(top);
        }
    }
}

