using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser
{
    public class OperationWrapper : AbstractMathObject, 
        IHasChildren, IHasOutput, IHasDisplayValue, ICanCopyByValue, IHasValue, ICanBeDefined
    {
        readonly IMathObject[] objs;

        readonly IMathOperation op;

        readonly IMathObject output;

        public OperationWrapper(
            IMathObject[] objs, 
            IMathOperation op)
        {
            this.objs = objs;
            this.op = op;
            this.output = op.Perform(objs);
        }

        public OperationWrapper(
            IMathObject[] objs, 
            IMathOperation op,
            IMathObject output)
        {
            this.objs = objs;
            this.op = op;
            this.output = output;
        }

        public IMathObject[] Children
        {
            get { return this.objs; }
        }

        public bool IsDefinded 
        { 
            get 
            {
                var defined = output as ICanBeDefined;
                if (defined != null)
                {
                    return defined.IsDefinded;
                }

                var hasOutput = output as IHasOutput;
                if (hasOutput != null)
                {
                    var defined2 = hasOutput.Output as ICanBeDefined;
                    if (defined2 != null)
                    {
                        return defined2.IsDefinded;
                    }
                }

                return true;
            }
        }

        public IMathObject Output
        {
            get { return this.output; }
        }

        public IMathValue Value 
        { 
            get 
            { 
                var hasValue = output as IHasValue;
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

            return new OperationWrapper(list.ToArray(), this.op, this.output);
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

                var hasDisplay = obj as IHasDisplayValue;
				if (hasDisplay != null)
				{
					s += hasDisplay.DisplayValue;
				}
				else
				{
					s += obj.ToString();
				}

                first = false;
            }

            return s;
        }
    }
}

