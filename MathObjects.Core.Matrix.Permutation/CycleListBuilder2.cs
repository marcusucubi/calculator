using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Core.Matrix.Permutation
{
    class CycleListBuilder2
    {
        public CycleList Build(PermutationMatix matrix)
        {
            return this.Build(matrix.Switches);
        }

        public CycleList Build(int[] switches)
        {
            var init = new CycleListInit();

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

            var stack = new List<Move>();
            foreach(var move in init.Moves)
            {
                stack.Add(move);
            }

            var moves = new Moves(init.Moves);

            var largeList = new List<int>();

            while (stack.Count > 0)
            {
                var smallList = new List<int>();

                stack = new List<Move>(stack.OrderBy(x => x.From));

                var first = stack.First();
                stack.Remove(first);

                //for (int temp = 1; temp < first.From; temp++)
                //{
                //    smallList.Add(temp);
                //}

                smallList.Add(first.From);
                largeList.Add(first.From);

                var cursor = moves.GetNext(first);

                if (stack.Contains(cursor))
                {
                    stack.Remove(cursor);
                }

                while (cursor.From != first.From)
                {
                    smallList.Add(cursor.From);
                    largeList.Add(cursor.From);

                    cursor = moves.GetNext(cursor);

                    if (stack.Contains(cursor))
                    {
                        stack.Remove(cursor);
                    }
                }

                init.CycleSet.Add(smallList);
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

