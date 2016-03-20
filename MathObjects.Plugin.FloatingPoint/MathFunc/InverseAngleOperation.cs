using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleOperation : IMathOperation
    {
        readonly MathHandler handler;

        readonly string symbol;

        public int NumberOfParameters { get { return 1; } }

        public string Symbol { get { return symbol; } }

        public InverseAngleOperation(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
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

            readonly string symbol;

            public Factory(MathHandler handler, string symbol)
            {
                this.handler = handler;
                this.symbol = symbol;
            }

            public IMathOperation Create(object param)
            {
                return new InverseAngleOperation(handler, symbol);
            }
        }
    }
}

