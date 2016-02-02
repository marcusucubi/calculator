using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    public enum AngleType
    {
        Radians, Degrees
    }

    class AngleObject : IMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double angleValue;

        readonly AngleType angleType;

        readonly string name;

        public AngleObject(double value, AngleType angleType, string name)
        {
            this.angleValue = value;
            this.angleType = angleType;
        }

        public AngleObject(AngleObject obj)
        {
            this.angleValue = obj.angleValue;
            this.angleType = obj.angleType;
            this.name = obj.Name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public AngleType AngleType
        {
            get { return this.angleType; }
        }

        public double AngleValue
        {
            get { return this.angleValue; }
        }

        public object Output { get { return this.angleValue; } }

        public string DisplayValue
        {
            get 
            {
                return Output.ToString() + 
                    ((this.angleType==AngleType.Degrees) ? " degrees" : " radians"); 
            }
        }

        public AngleObject ConvertToDegrees()
        {
            double result = this.angleValue;

            if (this.angleType == AngleType.Radians)
            {
                result = Convert.RadiansToDegrees(this.angleValue);
            }

            return new AngleObject(result, AngleType.Degrees, this.name);
        }

        public AngleObject ConvertToRadians()
        {
            double result = this.angleValue;

            if (this.angleType == AngleType.Degrees)
            {
                result = Convert.DegreesToRadians(this.angleValue);
            }

            return new AngleObject(result, AngleType.Radians, this.name);
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

