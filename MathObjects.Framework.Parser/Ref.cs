using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework.Parser
{
    public class Ref : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, IHasChildren, 
        ICanCopyByValue, ICanEvaluate
    {
        readonly IMathScope scope;

        readonly string name;

        public Ref(IMathScope scope, string name)
        {
            this.scope = scope;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public IMathObject MathObject
        {
            get 
            {
                var result = this.scope.Get(this.name);

                var eval = result as ICanEvaluate;
                if (eval != null)
                {
                    result = eval.ReEvaluate();
                }

                return result;
            }
        }

        public IMathObject Output
        {
            get { return this.scope.Get(this.name); }
        }

        public IMathObject[] Children
        {
            get { return new IMathObject[] { this.scope.Get(this.name) }; }
        }

        public string DisplayValue 
        { 
            get { return this.name; }
        }

        public IMathObject CopyByValue()
        {
            var result = new ValueRef(this.scope, this.name);

            result.CopyDecorations(this);

            return result;
        }

        public IMathObject ReEvaluate()
        {
            var result = new ValueRef(this.scope, this.name);

            var result2 = result.ReEvaluate();

            result2.CopyDecorations(this);

            return result2;
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}


