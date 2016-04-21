using System;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace MathObjects.Framework.Parser
{
    public class ParserException : Exception 
    {
        readonly List<Description> list;

        public List<Description> Descriptions
        {
            get { return this.list; }
        }

        public ParserException(List<Description> descriptions)
        {
            this.list = descriptions;
        }

        public class Description
        {
            public IToken OffendingSymbol { get; set; }
            public int Line { get; set; }
            public int CharPositionInLine { get; set; }
            public string Msg { get; set; } 

            public override string ToString()
            {
                return "'" + Msg + "' at " + CharPositionInLine + " in " + Line;
            }
        }
    }
}

