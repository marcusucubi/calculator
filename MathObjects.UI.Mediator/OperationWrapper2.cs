using System;
using MathObjects.Framework;

namespace MathObjects.UI.Mediator
{
    public class OperationWrapper2 : 
        IMathObject, IHasChildren, IHasOutput
    {
        readonly IMathObject obj;

        readonly IMathOperation op;

        public OperationWrapper2(
            IMathObject obj, 
            IMathOperation op)
        {
            this.obj = obj;
            this.op = op;
        }

        public IMathObject[] Children
        {
            get { return new IMathObject[] { this.obj }; }
        }

        public object Output
        {
            get { return op.Perform(obj); }
        }
    }
}

