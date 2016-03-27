using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ValueRef : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, IHasChildren, ICanCopyByValue
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

                return "" + this.obj.GetDouble(); 
            }
        }

        public IMathObject CopyByValue()
        {
            var copy = this.obj as ICanCopyByValue;

            if (copy == null)
            {
                return new ErrorObject();
            }

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

