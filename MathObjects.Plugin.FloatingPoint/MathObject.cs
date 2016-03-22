using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    class MathObject : AbstractMathObject, IHasOutput, IHasDisplayValue, ICanCopyByValue 
    {
        readonly double value;

        public MathObject(double param)
        {
            value = param;
        }

        public object Output
        {
            get { return this.value; }
        }

        public string DisplayValue 
        { 
            get { return this.value.ToString(); }
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

