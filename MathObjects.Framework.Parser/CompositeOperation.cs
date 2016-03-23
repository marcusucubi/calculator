using System;
using System.Linq;
using MathObjects.Core.DecoratableObject;
using MathObjects.Core.Extension;

namespace MathObjects.Framework.Parser
{
    public class CompositeOperation : IMathOperation
    {
        readonly ExtensionCollection collection = new ExtensionCollection();

        readonly IMathOperation first;

        readonly IMathOperation second;

        public CompositeOperation(
            IMathOperation first, 
            IMathOperation second)
        {
            this.first = first;
            this.second = second;
        }

        public ExtensionCollection ExtensionCollection
        {
            get { return collection; }
        }

        public IMathOperation First
        {
            get { return this.first; }
        }

        public IMathOperation Second
        {
            get { return this.second; }
        }
 
        public int NumberOfParameters 
        { 
            get { return this.first.NumberOfParameters; } 
        }

        public string Symbol 
        { 
            get { return "composite"; } 
        }

        public object DecorationTarget 
        { 
            get { return this.second; } 
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var stack = new MathObjectStack();

            stack.Push(target[0]);

            stack.Push(first);

            var paramList = stack.Peek(second.NumberOfParameters);

            stack.Push(second);

            return second.Perform(paramList.ToArray());
        }
    }
}

