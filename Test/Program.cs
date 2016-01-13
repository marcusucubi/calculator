using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Tree;
using System.IO;
using MathObjects.Plugin.Symmetric.Parser;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                var input = new AntlrInputStream("( 1, 2 )");
                var lexer = new PermutationLexer(input);
                var tokens = new CommonTokenStream(lexer);
                var parser = new PermutationParser(tokens);

                var tree = parser.init(); 
                Console.WriteLine(tree.ToStringTree(parser));

                var walker = new ParseTreeWalker();
                var builder = new PermutationBuilder();

                walker.Walk(builder, tree);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            var result = parser.startProg();

            // Use the tree to do the evaluation
            var tree = (CommonTree)result.Tree;
            var nodes = new CommonTreeNodeStream(tree);
            var walker = new PolynomialTree(nodes);
            double xStep = (xHigh - xLow) / 10.0;
            for (double x = xLow; x <= xHigh; x += xStep)
            {
                nodes.Reset();
                double value = walker.start(x);
                Console.WriteLine("f(" + x + ") = " + value);
            }
*/
        }
    }
    /*
    public class EvalVisitor : Antlr4.Runtime.Tree.AbstractParseTreeVisitor<int> 
    {
        public int visitOpExpr(CalculatorLexer.OpExprContext ctx) 
        {
            int left = visit(ctx.left);
            int right = visit(ctx.right);
            String op = ctx.op.getText();
            switch (op.Substring(0, 1)) 
            {
                case '*': return left * right;
                case '/': return left / right;
                case '+': return left + right;
                case '-': return left - right;
                default: throw new Exception("Unknown operator " + op);
            }
        }

        public int visitStart(ExpressionsParser.StartContext ctx) 
        {
            return this.visit(ctx.expr());
        }

        public int visitAtomExpr(ExpressionsParser.AtomExprContext ctx) 
        {
            return int.valueOf(ctx.getText());
        }

        public int visitParenExpr(ExpressionsParser.ParenExprContext ctx) 
        {
            return this.visit(ctx.expr());
        }

        public static void main(String[] args) 
        {
            String expression = "2 * (3 + 4)";
            var lexer = new ExpressionsLexer(new ANTLRInputStream(expression));
            var parser = new ExpressionsParser(new CommonTokenStream(lexer));
            var tree = parser.start();
            var answer = new EvalVisitor().visit(tree);
            Console.WriteLine("" + expression + " " + answer);
        }
        */
    //}
}
