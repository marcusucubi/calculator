using System;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using Gtk;

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

            try
            {
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
            }
            catch (ParserException e)
            {
                var msg = e.Descriptions[0].ToString();

                var dlg = new MessageDialog(
                    null, DialogFlags.DestroyWithParent, MessageType.Error, 
                    ButtonsType.Close, "{0}", msg);

                dlg.Run();
                dlg.Destroy();

                result = false;
            }

            return result;
        }
    }
}

