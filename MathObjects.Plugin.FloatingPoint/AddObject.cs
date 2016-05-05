using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "+")]
    class AddObject : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, ICanCopyByValue, IHasValue, ICanEvaluate  
    {
        readonly IMathObject[] objs;

        readonly double leftValue;

        readonly double rightValue;

        public AddObject(IMathObject[] objs)
        {
            this.objs = objs;

            if (objs[0].IsDefined() && objs[1].IsDefined())
            {
                this.leftValue = objs[0].GetDouble();
                this.rightValue = objs[1].GetDouble();
            }
        }

        public IMathObject Output
        {
            get
            {
                if (!objs[0].IsDefined() || !objs[1].IsDefined())
                {
                    var result = new UndefinedObject();

                    result.SetObjectName("+");

                    return result;
                }

                return new MathObject(leftValue + rightValue); 
            }
        }

        public IMathValue Value 
        { 
            get 
            { 
                if (!objs[0].IsDefined() || !objs[1].IsDefined())
                {
                    var result = new UndefinedValue();

                    result.SetObjectName("+");

                    return result;
                }

                return new MathValue(leftValue + rightValue); 
            } 
        }

        public string DisplayValue 
        { 
            get { return this.Output.ToString(); }
        }

        public IMathObject CopyByValue()
        {
            return this;
        }

        public IMathObject ReEvaluate()
        {
            return new AddObject(this.objs);
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

