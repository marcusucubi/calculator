using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    class Inverse : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "inverse"; } }

        public override IMathObject Perform(IMathObject[] target)
        {
            if (!target[0].IsDefined())
            {
                return new UndefinedObject();
            }

            var tuple = target[0].GetTuple();
            if (tuple != null)
            {
                return new InverseObject(tuple);
            }

            throw new Exception();
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Inverse"; }
            }

            public IMathOperation Create(object param)
            {
                return new Inverse();
            }
        }
    }
}

