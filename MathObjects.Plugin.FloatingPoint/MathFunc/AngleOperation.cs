using System;
using MathObjects.Framework;

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
                angle = new AngleObject(target[0].GetDouble(), AngleType.Degrees);
            }

            return new MathObject(handler(angle.ConvertToRadians().AngleValue));
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
                return new AngleOperation(handler);
            }
        }
    }
}

