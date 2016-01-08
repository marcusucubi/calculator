using System;
using System.Collections.Generic;

namespace MathObjects.Core.Matrix.Permutation
{
    public class Move
    {
        readonly int fromValue;

        readonly int toValue;

        public Move(IEnumerable<int> list)
        {
            var e = list.GetEnumerator();
            e.MoveNext();
            this.fromValue = e.Current;
            e.MoveNext();
            this.toValue = e.Current;
        }

        public Move(int from, int to)
        {
            this.fromValue = from;
            this.toValue = to;
        }

        public int From { get { return this.fromValue; } }

        public int To { get { return this.toValue; } }

        public override string ToString()
        {
            return "(" + this.fromValue + "->" + this.toValue + ")";
        }
    }
}

