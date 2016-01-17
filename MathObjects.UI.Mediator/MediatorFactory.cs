using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    public static class MediatorFactory
    {
        public static IMediator Create(FactoryRegistry registry)
        {
            return new CalcMediator(registry);
        }
    }
}
