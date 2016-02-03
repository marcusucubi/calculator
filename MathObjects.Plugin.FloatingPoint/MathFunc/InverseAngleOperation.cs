using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleOperation : IMathOperation, IHasName, ICanSetName 
    {
        readonly MathHandler handler;

        public int NumberOfParameters { get { return 1; } }

        public string Name { get; set; }

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

