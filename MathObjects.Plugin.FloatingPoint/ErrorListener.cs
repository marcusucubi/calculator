using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;
using Antlr4.Runtime.Atn;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FoatingPoint
{
    public class ErrorListener : BaseErrorListener
    {
        readonly List<ParserException.Description> list = new List<ParserException.Description>();

        public List<ParserException.Description> Descriptions
        {
            get { return this.list; }
        }

        public bool HasError
        {
            get { return this.list.Count > 0; }
        }

        public override void ReportAmbiguity(
            Antlr4.Runtime.Parser recognizer, 
            DFA dfa, 
            int startIndex, 
            int stopIndex, 
            bool exact, 
            BitSet ambigAlts, 
            ATNConfigSet configs)
        {
        }

        public override void ReportAttemptingFullContext(
            Antlr4.Runtime.Parser recognizer, 
            DFA dfa, 
            int startIndex, 
            int stopIndex, 
            BitSet conflictingAlts, 
            SimulatorState conflictState)
        {
        }

        public override void ReportContextSensitivity(
            Antlr4.Runtime.Parser recognizer, 
            DFA dfa, 
            int startIndex, 
            int stopIndex, 
            int prediction, 
            SimulatorState acceptState)
        {
        }

        public override void SyntaxError(
            IRecognizer recognizer, 
            IToken offendingSymbol, 
            int line, 
            int charPositionInLine, 
            string msg, 
            RecognitionException e)
        {
            var desc = new ParserException.Description();
            desc.CharPositionInLine = charPositionInLine;
            desc.Line = line;
            desc.Msg = msg;
            desc.OffendingSymbol = offendingSymbol;
            this.list.Add(desc);
        }

    }
}

