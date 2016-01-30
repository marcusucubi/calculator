using System;
using MathObjects.Framework;

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

        public IMathObject Perform(IMathObject target)
        {
            double value = target.GetDouble();

            return new AngleObject(handler(value), AngleType.Radians);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            readonly string name;

            readonly MathHandler handler;

            public Factory(string name, MathHandler handler)
            {
                this.name = name;
                this.handler = handler;
            }

            public string Name
            {
                get { return name; }
            }

            public IMathOperation Create(object param)
            {
                return new InverseAngleOperation(handler);
            }
        }
    }
}

