using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Ref : IMathObject, IHasOutput, IHasDisplayValue, IHasChildren, ICanCopyByValue
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
            get { return this.scope.Get(this.name); }
        }

        public object Output
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

        public override string ToString()
        {
            return "ref(" + DisplayValue + ")";
        }
    }
}

