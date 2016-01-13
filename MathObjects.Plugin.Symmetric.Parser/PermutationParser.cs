//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Permutation.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class PermutationParser : Parser {
	public const int
		T__0=1, T__1=2, T__2=3, INT=4, WS=5;
	public const int
		RULE_init = 0, RULE_value = 1;
	public static readonly string[] ruleNames = {
		"init", "value"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "','", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "INT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Permutation.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public PermutationParser(ITokenStream input)
		: base(input)
	{
		Interpreter = new ParserATNSimulator(this,_ATN);
	}
	public partial class InitContext : ParserRuleContext {
		public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		public InitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_init; } }
		public override void EnterRule(IParseTreeListener listener) {
			IPermutationListener typedListener = listener as IPermutationListener;
			if (typedListener != null) typedListener.EnterInit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPermutationListener typedListener = listener as IPermutationListener;
			if (typedListener != null) typedListener.ExitInit(this);
		}
	}

	[RuleVersion(0)]
	public InitContext init() {
		InitContext _localctx = new InitContext(Context, State);
		EnterRule(_localctx, 0, RULE_init);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4; Match(T__0);
			State = 5; value();
			State = 10;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==T__1) {
				{
				{
				State = 6; Match(T__1);
				State = 7; value();
				}
				}
				State = 12;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 13; Match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		public ITerminalNode INT() { return GetToken(PermutationParser.INT, 0); }
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		public override void EnterRule(IParseTreeListener listener) {
			IPermutationListener typedListener = listener as IPermutationListener;
			if (typedListener != null) typedListener.EnterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPermutationListener typedListener = listener as IPermutationListener;
			if (typedListener != null) typedListener.ExitValue(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 2, RULE_value);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 15; Match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x3\a\x14\x4\x2\t\x2"+
		"\x4\x3\t\x3\x3\x2\x3\x2\x3\x2\x3\x2\a\x2\v\n\x2\f\x2\xE\x2\xE\v\x2\x3"+
		"\x2\x3\x2\x3\x3\x3\x3\x3\x3\x2\x2\x4\x2\x4\x2\x2\x12\x2\x6\x3\x2\x2\x2"+
		"\x4\x11\x3\x2\x2\x2\x6\a\a\x3\x2\x2\a\f\x5\x4\x3\x2\b\t\a\x4\x2\x2\t\v"+
		"\x5\x4\x3\x2\n\b\x3\x2\x2\x2\v\xE\x3\x2\x2\x2\f\n\x3\x2\x2\x2\f\r\x3\x2"+
		"\x2\x2\r\xF\x3\x2\x2\x2\xE\f\x3\x2\x2\x2\xF\x10\a\x5\x2\x2\x10\x3\x3\x2"+
		"\x2\x2\x11\x12\a\x6\x2\x2\x12\x5\x3\x2\x2\x2\x3\f";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
