using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantOperation : DecoratableObject, IMathOperation, IHasName 
    {
        readonly double value;

        readonly string name;

        public int NumberOfParameters { get { return 0; } }

        public ConstantOperation(double value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var result = new ConstantObject(value, this.name);

            result.CopyDecorations(this);

            return result;
        }
    }
}

