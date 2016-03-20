using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleOperation : IMathOperation
    {
        readonly MathHandler handler;

        readonly string symbol;

        public int NumberOfParameters { get { return 1; } }

        public string Symbol { get { return symbol; } }

        public AngleOperation(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
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

            readonly string symbol;

            public Factory(MathHandler handler, string symbol)
            {
                this.handler = handler;
                this.symbol = symbol;
            }

            public IMathOperation Create(object param)
            {
                return new AngleOperation(handler, symbol);
            }
        }
    }
}

