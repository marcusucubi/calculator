using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Ref : IMathObject, IHasOutput, IHasDisplayValue, IHasChildren
    {
        readonly IMathScope scope;

        readonly string name;

        public Ref(IMathScope scope, string name)
        {
            this.scope = scope;
            this.name = name;
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

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

