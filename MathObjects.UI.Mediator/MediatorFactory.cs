using System;
using MathObjects.Framework;

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

