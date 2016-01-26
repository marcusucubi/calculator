using System;
using MathObjects.Framework;

namespace MathObjects.Framework.Parser
{
    public class BinaryOperationWrapper : 
        IMathObject, IHasChildren, IHasOutput
    {
        readonly IMathObject obj1;

        readonly IMathObject obj2;

        readonly IMathBinaryOperation op;

        public BinaryOperationWrapper(
            IMathObject obj1, 
            IMathObject obj2, 
            IMathBinaryOperation op)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.op = op;
        }

        public IMathObject[] Children
        {
            get { return new IMathObject[] { this.obj1, this.obj2 }; }
        }

        public object Output
        {
            get { return op.Perform(obj1, obj2); }
        }
    }
}

