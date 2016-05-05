using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework.Parser
{
    public class ValueRef : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, IHasChildren, 
        ICanEvaluate, ICanCopyByValue, IHasValue
    {
        readonly string name;

        readonly IMathObject obj;

        readonly IMathScope scope;

        public ValueRef(IMathScope scope, string name)
        {
            var referance = new Ref(scope, name);

            this.name = referance.Name;
            this.obj = referance.MathObject.CopyByValue();
            this.scope = scope;

            this.SetObjectName(name);
        }

        public string Name
        {
            get { return this.name; }
        }

        public IMathObject MathObject
        {
            get { return this.obj; }
        }

        public IMathValue Value 
        { 
            get 
            { 
                var hasValue = this.MathObject as IHasValue;
                if (hasValue != null)
                {
                    return hasValue.Value;
                }

                return null; 
            } 
        }

        public IMathObject Output
        {
            get { return this.obj; }
        }

        public IMathObject[] Children
        {
            get { return new IMathObject[] { this.obj }; }
        }

        public string DisplayValue 
        { 
            get 
            { 
                var hasDisplay = obj as IHasDisplayValue;
                if (hasDisplay != null)
                {
                    return hasDisplay.DisplayValue;
                }

                return "" + this.obj; 
            }
        }

        public IMathObject CopyByValue()
        {
            var copy = this.obj as ICanCopyByValue;

            if (copy == null)
            {
                return this.obj;
            }

            var result = copy.CopyByValue();

            result.CopyDecorations(this);

            return result;
        }

        public IMathObject ReEvaluate()
        {
            var result = new ValueRef(this.scope, this.name);

            var eval = result.MathObject as ICanEvaluate;
            if (eval != null)
            {
                return eval.ReEvaluate();
            }

            return result;
        }

        public override string ToString()
        {
            return "value(" + DisplayValue + ")";
        }
    }
}


