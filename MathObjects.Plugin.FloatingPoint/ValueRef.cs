using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ValueRef : AbstractMathObject, IHasOutput, IHasDisplayValue, IHasChildren, ICanCopyByValue
    {
        readonly string name;

        readonly IMathObject obj;

        public ValueRef(IMathScope scope, string name)
        {
            var referance = new Ref(scope, name);

            this.name = referance.Name;
            this.obj = referance.MathObject.CopyByValue();

            DecorationManager.SetObjectDecoration(
                this, "name", name);
        }

        public string Name
        {
            get { return this.name; }
        }

        public IMathObject MathObject
        {
            get { return this.obj; }
        }

        public object Output
        {
            get { return this.obj; }
        }

        public IMathObject[] Children
        {
            get { return new IMathObject[] { this.obj }; }
        }

        public string DisplayValue 
        { 
            get { return "" + this.obj.GetDouble(); }
        }

        public IMathObject CopyByValue()
        {
            var copy = this.obj as ICanCopyByValue;

            var result = copy.CopyByValue();

            result.CopyDecorations(this);

            return result;
        }

        public override string ToString()
        {
            return "value(" + DisplayValue + ")";
        }
    }
}

