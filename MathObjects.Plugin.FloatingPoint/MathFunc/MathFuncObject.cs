using System;
using MathObjects.Framework.Registry;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    public static class MathFuncObject
    {
        public static void Init(FunctionRegistry registry)
        {
            registry.Put(
                "cos", new AngleFunction.Factory(x => Math.Cos(x)));
            
            registry.Put(
                "sin", new AngleFunction.Factory(x => Math.Sin(x)));
            
            registry.Put(
                "tan", new AngleFunction.Factory(x => Math.Tan(x)));
            
            registry.Put(
                "acos", new InverseAngleFunction.Factory(x => Math.Acos(x)));
            
            registry.Put(
                "asin", new InverseAngleFunction.Factory(x => Math.Asin(x)));

            registry.Put(
                "atan", new InverseAngleFunction.Factory(x => Math.Atan(x)));

            registry.Put(
                "abs", new MathFunction.Factory(x => System.Math.Abs(x)));
            
            registry.Put(
                "exp", new MathFunction.Factory(x => System.Math.Exp(x)));
            
            registry.Put(
                "log", new MathFunction.Factory(x => System.Math.Log(x)));
            
            registry.Put(
                "sqrt", new MathFunction.Factory(x => System.Math.Sqrt(x)));
        }
    }
}

