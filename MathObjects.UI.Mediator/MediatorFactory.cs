using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    public static class MediatorFactory
    {
        public static IMediator Create(IParser parser)
        {
            return new CalcMediator(parser);
        }
    }
}
