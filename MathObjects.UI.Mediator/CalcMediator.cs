using System;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    class CalcMediator : MathObjectStack, IMediator
    {
        readonly IParser parser;

        readonly IMathObjectFactory objectFactory;

        readonly IMathScope scope = new MathScope();

        public CalcMediator(
            IParser parser)
        {
            this.parser = parser;
        }

        public bool Enter(string input)
        {
            bool result = true;

            if (parser != null)
            {
                parser.Parse(input, this, scope);

                result = !parser.HasError;
            }
            else
            {
                var context = new FactoryContext();
                context.InitObject = input;
                var obj = this.objectFactory.Create(context);
                if (obj != null)
                {
                    Push(obj);
                }
            }

            return result;
        }
    }
}

