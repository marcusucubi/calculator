using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleOperation : AbstractMathOperation
    {
        readonly MathHandler handler;

        readonly string symbol;

        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return symbol; } }

        public AngleOperation(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
        }
            
        public override IMathObject Perform(IMathObject[] target)
        {
            if (!target[0].IsDefined())
            {
                var undef = new UndefinedObject();

                DecorationManager.SetObjectDecoration(undef, "name", this.Symbol);

                return undef;
            }

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

