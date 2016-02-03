using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    delegate double MathHandler(double input);

    class MathOperation : IMathOperation
    {
        readonly MathHandler handler;

        public int NumberOfParameters { get { return 1; } }

        public MathOperation(MathHandler handler)
        {
            this.handler = handler;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var result = new MathObject(handler(target[0].GetDouble()));

            result.CopyDecorations(this);

            return result;
        }

        public class Factory : IMathOperationFactory
        {
            readonly MathHandler handler;

            public Factory(MathHandler handler)
            {
                this.handler = handler;
            }

            public IMathOperation Create(object param)
            {
                return new MathOperation(handler);
            }
        }
    }
}

