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

        public static CycleList Create(PermutationMatix matrix)
        {
            return new CycleListBuilder2().Build(matrix);
        }

        internal CycleList(CycleListInit init)
        {
            this.init = new CycleListInit(init);
        }

        public ReadOnlyCollection<int> CycleSet
        {
            get { return new ReadOnlyCollection<int>(init.CycleSet); }
        }

        public ReadOnlyCollection<int> PermutedList
        {
            get { return new ReadOnlyCollection<int>(init.PermutedList); }
        }

        public ReadOnlyCollection<Move> Moves
        {
            get { return new ReadOnlyCollection<Move>(init.Moves); }
        }
    }
}

