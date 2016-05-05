using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework.Parser
{
    class StackParamOperation : AbstractMathOperation
    {
        readonly IMathObject value;

        public override int NumberOfParameters { get { return 0; } }

        public override string Symbol { get { return "param"; } }

        public StackParamOperation(IMathObject value)
        {
            this.value = value;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            var result = new StackParamObject(value);

            result.CopyDecorations(this);

            return result;
        }
    }
}

