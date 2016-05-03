using System;
using System.Diagnostics;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor1 : FloatingPointBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        readonly InitVisitor init;

        readonly EvalProcessor1 processor;

        public IMathObjectStack Stack
        {
            get { return this.stack; }
        }

        public IMathObjectStack StackClone
        {
            get { return this.stackClone; }
        }

        public IMathScope Scope
        {
            get { return this.scope; }
        }

        public InitVisitor Init
        {
            get { return this.init; }
        }

        public EvalVisitor1(
            IMathObjectStack stack,
            IMathScope scope,
            InitVisitor init)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
            this.init = init;
            processor = new EvalProcessor1(this, stack, scope, init);
        }

        public override IMathObject VisitPrintExpr(
            FloatingPointParser.PrintExprContext context)
        {
            return processor.VisitPrintExpr(context);
        }

        public override IMathObject VisitVariable(
            FloatingPointParser.VariableContext context)
        {
            return processor.VisitVariable(context);
        }

        public override IMathObject VisitAssignment(
            FloatingPointParser.AssignmentContext context)
        {
            return processor.VisitAssignment(context);
        }

        public override IMathObject VisitExponent(
            FloatingPointParser.ExponentContext context)
        {
            return processor.VisitExponent(context);
        }

        public override IMathObject VisitParens(
            FloatingPointParser.ParensContext context)
        {
            return processor.VisitParens(context);
        }

        public override IMathObject VisitMulDiv(
            FloatingPointParser.MulDivContext context)
        {
            return processor.VisitMulDiv(context);
        }

        public override IMathObject VisitExprList(
            FloatingPointParser.ExprListContext context)
        {
            return processor.VisitExprList(context);
        }

        public override IMathObject VisitFuncCall(
            FloatingPointParser.FuncCallContext context)
        {
            return processor.VisitFuncCall(context);
        }

        public override IMathObject VisitStackParam(
            FloatingPointParser.StackParamContext context)
        {
            return processor.VisitStackParam(context);
        }
    }
}

