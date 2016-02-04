﻿using System;
using System.Linq;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework.Parser
{
    public class CompositeOperation : IMathOperation, IDecorationProxy
    {
        readonly IMathOperation first;

        readonly IMathOperation second;

        public CompositeOperation(
            IMathOperation first, 
            IMathOperation second)
        {
            this.first = first;
            this.second = second;
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

