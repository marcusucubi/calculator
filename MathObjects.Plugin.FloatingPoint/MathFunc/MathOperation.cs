using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    delegate double MathHandler(double input);

    class MathOperation : AbstractMathOperation
    {
        readonly MathHandler handler;

        readonly string symbol;

        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return symbol; } }

        public MathOperation(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            if (!target[0].IsDefined())
            {
                var undef = new UndefinedObject();

                NameManager.SetObjectName(undef, this.symbol);

                return undef;
            }

            var result = new MathObject(handler(target[0].GetDouble()));

            result.CopyDecorations(this);

            return result;
        }

        public override string ToString()
        {
            return this.symbol;
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
                return new MathOperation(handler, this.symbol);
            }
        }
    }
}

