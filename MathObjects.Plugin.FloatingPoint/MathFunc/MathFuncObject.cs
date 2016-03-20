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
                "cos", new AngleFunction.Factory(x => Math.Cos(x), "cos"));
            
            registry.Put(
                "sin", new AngleFunction.Factory(x => Math.Sin(x), "sin"));
            
            registry.Put(
                "tan", new AngleFunction.Factory(x => Math.Tan(x), "tan"));
            
            registry.Put(
                "acos", new InverseAngleFunction.Factory(x => Math.Acos(x), "acos"));
            
            registry.Put(
                "asin", new InverseAngleFunction.Factory(x => Math.Asin(x), "asin"));

            registry.Put(
                "atan", new InverseAngleFunction.Factory(x => Math.Atan(x), "atan"));

            registry.Put(
                "abs", new MathFunction.Factory(x => System.Math.Abs(x), "abs"));
            
            registry.Put(
                "exp", new MathFunction.Factory(x => System.Math.Exp(x), "exp"));
            
            registry.Put(
                "log", new MathFunction.Factory(x => System.Math.Log(x), "log"));
            
            registry.Put(
                "sqrt", new MathFunction.Factory(x => System.Math.Sqrt(x), "sqrt"));
        }
    }
}

