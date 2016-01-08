using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Plugin.Symmetric
{
    public class CycleList
    {
        readonly CycleListInit init;

        public CycleList(CycleListInit init)
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

