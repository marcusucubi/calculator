using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public class CycleListBuilder2
    {
        public CycleList Build(PermutationMatix matrix)
        {
            var init = new CycleListInit();

            var switches = matrix.Switches;

            init.PermutedList = new List<int>(switches);

            BuildMoves(init);

            BuildCycleList(init);

            return new CycleList(init);
        }

        /**
         * 1 2
         * 
         * 1->2   2->1
         */
        void BuildCycleList(CycleListInit init)
        {
            if (init.Moves.Count == 0)
            {
                return;
            }

            var moves = new Moves(init.Moves);

            var first = moves.First;
            Move cursor = moves.GetNext(first);

            init.CycleSet.Add(first.From);

            while(cursor.From != first.From)
            {
                init.CycleSet.Add(cursor.From);
                cursor = moves.GetNext(cursor);
            }
        }

        /**
         * 1 3 2
         * moves 2->3  3->2
         */
        void BuildMoves(CycleListInit init)
        {
            for (int i = 0; i < init.PermutedList.Count; i++)
            {
                var permValue = init.PermutedList[i];

                if (i + 1 != permValue)
                {
                    var move = new Move(permValue, i + 1);
                    init.Moves.Add(move);
                }
            }
        }
    }
}

