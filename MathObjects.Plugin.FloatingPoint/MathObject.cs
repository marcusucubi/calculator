using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.DecoratableObject;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    class MathObject : AbstractMathObject, IHasDisplayValue, ICanCopyByValue, IHasValue 
    {
        readonly double value;

        public MathObject(double param)
        {
            value = param;
        }

        public string DisplayValue 
        { 
            get { return this.value.ToString(); }
        }

        public IMathValue Value
        {
            get { return new MathValue(this.value); }
        }

        public IMathObject CopyByValue()
        {
            var result = new MathObject(this.value);

            result.CopyDecorations(this);

            return result;
        }

        public override string ToString()
        {
            return DisplayValue;
        }

        public class Factory : IMathObjectFactory
        {
            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new MathObject(0);
            }
        }
    }
}

