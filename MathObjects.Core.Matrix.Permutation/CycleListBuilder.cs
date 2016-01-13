using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Core.Matrix.Permutation
{
    class CycleListBuilder
    {
        public CycleList Build(int[] value)
        {
            var init = new CycleListInit();

            init.CycleSet.Add(new List<int>(value));

            //BuildCycleList(init, value);

            BuildMoves(init);

            var countingSet = BuildSetOfCycle(init);

            init.PermutedList = countingSet.DoMoves(init.Moves);

            return new CycleList(init);
        }

        public CycleList Build(string value)
        {
            var init = new CycleListInit();

            BuildCycleList(init, value);

            BuildMoves(init);

            var countingSet = BuildSetOfCycle(init);

            init.PermutedList = countingSet.DoMoves(init.Moves);

            return new CycleList(init);
        }

        void BuildCycleList(CycleListInit init, string value)
        {
            string[] bigParts = value.Split(')');

            foreach(var bigPart in bigParts)
            {
                if (bigPart.Trim().Length == 0)
                {
                    continue;
                }

                var del = new char[]{ '(', ')', ' ' };
                string clean = bigPart.Trim(del);
                string[] dirtyParts = clean.Split(' ');

                var list = new List<int>();

                foreach (var part in dirtyParts)
                {
                    int i = int.Parse(part);
                    list.Add(i);
                }

                init.CycleSet.Add(list);
            }
        }

        void BuildMoves(CycleListInit init)
        {
            foreach (var bigList in init.CycleSet)
            {
                var lastTwo = new List<int>();
                foreach (var part in bigList)
                {
                    lastTwo.Add(part);

                    if (lastTwo.Count >= 2)
                    {
                        var move = new Move(lastTwo);
                        init.Moves.Add(move);

                        lastTwo.RemoveAt(0);
                    }
                }

                {
                    int first = bigList.FirstOrDefault();
                    int last = bigList.LastOrDefault();

                    var move = new Move(last, first);

                    init.Moves.Add(move);
                }
            }
        }

        List<int> BuildSetOfCycle(CycleListInit init)
        {
            int size = 0;

            foreach(var list in init.CycleSet)
            {
                int temp = list.OrderBy(x => x).LastOrDefault();

                if (temp > size)
                {
                    size = temp;
                }
            }

            return BuildSet(size);
        }

        static List<int> BuildSet(int size)
        {
            var list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i + 1);
            }

            return list;
        }
    }
}

