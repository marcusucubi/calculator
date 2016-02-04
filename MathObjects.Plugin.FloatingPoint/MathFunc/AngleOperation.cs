using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleOperation : IMathOperation
    {
        readonly MathHandler handler;

        public int NumberOfParameters { get { return 1; } }

        public AngleOperation(MathHandler handler)
        {
            this.handler = handler;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();

            if (angle == null)
            {
                angle = new AngleObject(
                    target[0].GetDouble(), AngleType.Degrees);
            }

            double value = handler(angle.ConvertToRadians().AngleValue);

            var result = new MathObject(value);

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
                return new AngleOperation(handler);
            }
        }
    }
}

