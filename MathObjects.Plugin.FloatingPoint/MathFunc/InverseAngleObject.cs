using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly AngleObject angleObj;

        readonly MathHandler handler;

        public InverseAngleObject(AngleObject angleObj, MathHandler handler)
        {
            this.angleObj = angleObj;
            this.handler = handler;
        }

        public InverseAngleObject(InverseAngleObject obj)
        {
            this.angleObj = obj.angleObj;
            this.handler = obj.MathHandler;
        }

        public MathHandler MathHandler
        {
            get { return this.MathHandler; }
        }

        public AngleObject Input
        {
            get { return this.angleObj; }
        }

        public object Output 
        { 
            get 
            { 
                return this.handler(this.angleObj.AngleValue); 
            } 
        }

        public string DisplayValue
        {
            get 
            {
                return Output.ToString() + " input" +
                    ((this.angleObj.AngleType==AngleType.Degrees) ? " degrees" : " radians");
            }
        }

        public InverseAngleObject ConvertToDegrees()
        {
            var input = this.angleObj.ConvertToDegrees();

            return new InverseAngleObject(input, this.handler);
        }

        public InverseAngleObject ConvertToRadians()
        {
            var input = this.angleObj.ConvertToRadians();

            return new InverseAngleObject(input, this.handler);
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

