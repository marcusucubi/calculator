using System;
using Antlr4.Runtime.Tree;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using Antlr4.Runtime;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class GenericVisitor : AbstractParseTreeVisitor<object>
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

        public override object VisitChildren(IRuleNode node)
        {
            object result = null;

            var index = node.RuleContext.RuleIndex;

            string name = node.GetType().Name; 
            string clean = name.Remove(name.Length - "Context".Length);
            string full = "Visit" + clean;

            if (map.ContainsKey(full))
            {
                var m = map[full];

                result = m.Invoke(this.processor, new object[] {node});
            }

            return result;
        }

    }
}

