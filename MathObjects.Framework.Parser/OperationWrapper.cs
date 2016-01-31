using System;
using MathObjects.Framework;

namespace MathObjects.Framework.Parser
{
    public class OperationWrapper : 
        IMathObject, IHasChildren, IHasOutput, IHasName
    {
        readonly IMathObject[] objs;

        readonly IMathOperation op;

        readonly string name;

        public OperationWrapper(
            IMathObject[] objs, 
            IMathOperation op)
        {
            this.objs = objs;
            this.op = op;

            var hasName = op as IHasName;
            if (hasName != null)
            {
                name = hasName.Name;
            }
            else
            {
                name = "";
            }
        }

        public string Name
        {
            get { return this.name; }
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

