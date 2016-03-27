using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser
{
    public class OperationWrapper : AbstractMathObject, 
        IHasChildren, IHasOutput, IHasDisplayValue, ICanCopyByValue, IHasValue
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

        public IMathObject Output
        {
            get { return op.Perform(Children); }
        }

        public IMathValue Value 
        { 
            get 
            { 
                var hasValue = Output as IHasValue;
                if (hasValue != null)
                {
                    return hasValue.Value;
                }

                return null;
            } 
        }

        public string DisplayValue 
        { 
            get 
            { 
                var output = this.Output;

                var hasDisplay = output as IHasDisplayValue;
                if (hasDisplay != null)
                {
                    return hasDisplay.DisplayValue;
                }

                return "" + output; 
            } 
        }

        public IMathObject CopyByValue()
        {
            var list = new List<IMathObject>();

            foreach (var obj in this.objs)
            {
                list.Add(obj.CopyByValue());
            }

            return new OperationWrapper(list.ToArray(), this.op);
        }

        public override string ToString()
        {
            string s = "";

            bool first = true;

            foreach (var obj in this.objs)
            {
                if (!first)
                {
                    s += op.Symbol;
                }

                s += obj.ToString();

                first = false;
            }

            return s;
        }
    }
}

