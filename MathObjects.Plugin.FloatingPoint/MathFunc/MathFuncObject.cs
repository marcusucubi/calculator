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
                "cos", new AngleOperationFactory.Factory(x => Math.Cos(x), "cos"));
            
            registry.Put(
                "sin", new AngleOperationFactory.Factory(x => Math.Sin(x), "sin"));
            
            registry.Put(
                "tan", new AngleOperationFactory.Factory(x => Math.Tan(x), "tan"));
            
            registry.Put(
                "acos", new InverseAngleOperationFactory.Factory(x => Math.Acos(x), "acos"));
            
            registry.Put(
                "asin", new InverseAngleOperationFactory.Factory(x => Math.Asin(x), "asin"));

            registry.Put(
                "atan", new InverseAngleOperationFactory.Factory(x => Math.Atan(x), "atan"));

            registry.Put(
                "abs", new MathOperationFactory.Factory(x => System.Math.Abs(x), "abs"));
            
            registry.Put(
                "exp", new MathOperationFactory.Factory(x => System.Math.Exp(x), "exp"));
            
            registry.Put(
                "log", new MathOperationFactory.Factory(x => System.Math.Log(x), "log"));
            
            registry.Put(
                "sqrt", new MathOperationFactory.Factory(x => System.Math.Sqrt(x), "sqrt"));
        }
    }
}

