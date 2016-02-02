using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleOperation : IMathOperation
    {
        readonly MathHandler handler;

        readonly string name;

        public int NumberOfParameters { get { return 1; } }

        public AngleOperation(MathHandler handler, string name)
        {
            this.handler = handler;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();

            if (angle == null)
            {
                angle = new AngleObject(
                    target[0].GetDouble(), AngleType.Degrees, this.name);
            }

            double value = handler(angle.ConvertToRadians().AngleValue);

            return new MathObjectWithName(value, this.name);
        }

        public class Factory : IMathOperationFactory
        {
            readonly string name;

            readonly MathHandler handler;

            public Factory(string name, MathHandler handler)
            {
                this.name = name;
                this.handler = handler;
            }

            public IMathOperation Create(object param)
            {
                return new AngleOperation(handler, name);
            }
        }
    }
}

