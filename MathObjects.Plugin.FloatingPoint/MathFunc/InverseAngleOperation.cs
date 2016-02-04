using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleOperation : IMathOperation
    {
        readonly MathHandler handler;

        public int NumberOfParameters { get { return 1; } }

        public InverseAngleOperation(MathHandler handler)
        {
            this.handler = handler;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            double value = target[0].GetDouble();

            var result = new AngleObject(handler(value), AngleType.Radians);

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
                return new InverseAngleOperation(handler);
            }
        }
    }
}

