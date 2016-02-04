using System;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    public static class MathFuncObject
    {
        public static void Init(FactoryRegistry registry)
        {
            registry.RegisterFunctionFactory(
                "cos", new AngleFunction.Factory(x => Math.Cos(x)));
            
            registry.RegisterFunctionFactory(
                "sin", new AngleFunction.Factory(x => Math.Sin(x)));
            
            registry.RegisterFunctionFactory(
                "tan", new AngleFunction.Factory(x => Math.Tan(x)));
            
            registry.RegisterFunctionFactory(
                "acos", new InverseAngleFunction.Factory(x => Math.Acos(x)));
            
            registry.RegisterFunctionFactory(
                "asin", new InverseAngleFunction.Factory(x => Math.Asin(x)));

            registry.RegisterFunctionFactory(
                "atan", new InverseAngleFunction.Factory(x => Math.Atan(x)));

            registry.RegisterFunctionFactory(
                "abs", new MathFunction.Factory(x => System.Math.Abs(x)));
            
            registry.RegisterFunctionFactory(
                "exp", new MathFunction.Factory(x => System.Math.Exp(x)));
            
            registry.RegisterFunctionFactory(
                "log", new MathFunction.Factory(x => System.Math.Log(x)));
            
            registry.RegisterFunctionFactory(
                "sqrt", new MathFunction.Factory(x => System.Math.Sqrt(x)));
        }
    }
}

