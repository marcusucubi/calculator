using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework.Parser
{
    public class OperationWrapper : 
        IMathObject, IHasChildren, IHasOutput
    {
        readonly IMathObject[] objs;

        readonly IMathOperation op;

        public OperationWrapper(
            IMathObject[] objs, 
            IMathOperation op)
        {
            this.objs = objs;
            this.op = op;
        }

        public IMathObject[] Children
        {
            get { return this.objs; }
        }

        public object Output
        {
            get { return op.Perform(Children); }
        }
    }
}

