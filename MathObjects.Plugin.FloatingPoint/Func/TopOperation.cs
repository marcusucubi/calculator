using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopOperation : IMathOperation, IHasName, ICanSetName
    {
        readonly IMathObject top;

        string name;

        public int NumberOfParameters { get { return 0; } }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public TopOperation(IMathObjectStack stack, IMathObject top)
        {
            this.top = top;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            if (top is IIsError)
            {
                return top;
            }

            return new TopObject(top);
        }
    }
}

