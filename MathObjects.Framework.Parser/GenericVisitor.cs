using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathObjects.Framework;

namespace MathObjects.Framework.Parser
{
    public class GenericVisitor<Result> : AbstractParseTreeVisitor<Result>
    {
        readonly object processor;

        readonly IDictionary<string, MethodInfo> map = 
            new Dictionary<string, MethodInfo>();

        public GenericVisitor(object processor)
        {
            this.processor = processor;

            foreach (var m in this.processor.GetType().GetMethods())
            {
                map[m.Name] = m;
            }
        }

        public override Result Visit(IParseTree tree)
        {
            return Process(tree);
        }

        public override Result VisitTerminal(ITerminalNode node)
        {
            return Process(node);
        }

        public override Result VisitChildren(IRuleNode node)
        {
            return Process(node);
        }

        public Result Process(object node)
        {
            Result result = default(Result);

            string name = node.GetType().Name; 
            string clean = name.Remove(name.Length - "Context".Length);
            string full = "Visit" + clean;

            if (map.ContainsKey(full))
            {
                var m = map[full];

                result = (Result)m.Invoke(this.processor, new object[] { node, this });
            }

            return result;
        }
    }
}

