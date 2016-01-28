using System;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    class CalcMediator : MathObjectStack, IMediator
    {
        readonly FactoryRegistry registry;

        readonly IParser parser;

        readonly IMathObjectFactory objectFactory;

        public CalcMediator(
            FactoryRegistry registry,
            IParser parser)
        {
            this.registry = registry;
            this.parser = parser;

            objectFactory = registry.GetObjectFactory(FactoryRegistry.OBJECT);
        }

        public FactoryRegistry Registry
        {
            get { return this.registry; }
        }

        public void Enter(string input)
        {
            if (parser != null)
            {
                parser.Parse(input, this);
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
        }
    }
}

