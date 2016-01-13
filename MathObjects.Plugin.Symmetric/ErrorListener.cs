using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;
using Antlr4.Runtime.Atn;
using MathObjects.Framework;

namespace MathObjects.Plugin.Symmetric
{
    public class ErrorListener : BaseErrorListener
    {
        public bool HasError
        {
            get;
            protected set;
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
            var s = "line "+line+":"+charPositionInLine+" at "+
                offendingSymbol+": "+msg;
            ErrorHandler.SendError(this, s);

            this.HasError = true;
        }
    }
}

