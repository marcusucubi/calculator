using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Core.Matrix.Permutation
{
    public class CycleList
    {
        readonly CycleListInit init;

        public static CycleList Create(string value)
        {
            return new CycleListBuilder().Build(value);
        }

        public static CycleList Create(int[] value)
        {
            return new CycleListBuilder().Build(value);
        }

        public static CycleList Create(PermutationMatix matrix)
        {
            return new CycleListBuilder2().Build(matrix);
        }

        internal CycleList(CycleListInit init)
        {
            this.init = new CycleListInit(init);
        }

        public ReadOnlyCollection<ReadOnlyCollection<int>> CycleSet
        {
            get 
            { 
                var result = new List<ReadOnlyCollection<int>>();

                foreach (var child in init.CycleSet)
                {
                    var list = new ReadOnlyCollection<int>(child);
                    result.Add(list);
                }

                return new ReadOnlyCollection<ReadOnlyCollection<int>>(result); 
            }
        }

        public ReadOnlyCollection<int> PermutedList
        {
            get { return new ReadOnlyCollection<int>(init.PermutedList); }
        }

        public ReadOnlyCollection<Move> Moves
        {
            get { return new ReadOnlyCollection<Move>(init.Moves); }
        }

        public PermutationMatix ToMatrix()
        {
            return PermutationMatix.Create(this.PermutedList.ToArray());
        }

        public override string ToString()
        {
            string s = "(";

            foreach(var pos in this.CycleSet)
            {
                s += " " + pos;
            }

            s += " )";

            return s;
        }
    }
}

