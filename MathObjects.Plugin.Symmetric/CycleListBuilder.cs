using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Plugin.Symmetric
{
    public class CycleListBuilder
    {
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
            var del = new char[]{ '(', ')', ' ' };
            string clean = value.Trim(del);
            string[] dirtyParts = clean.Split(' ');

            foreach (var part in dirtyParts)
            {
                int i = int.Parse(part);
                init.CycleSet.Add(i);
            }
        }

        void BuildMoves(CycleListInit init)
        {
            var lastTwo = new List<int>();
            foreach (var part in init.CycleSet)
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
                int first = init.CycleSet.FirstOrDefault();
                int last = init.CycleSet.LastOrDefault();

                var move = new Move(last, first);

                init.Moves.Add(move);
            }
        }

        List<int> BuildSetOfCycle(CycleListInit init)
        {
            int size = init.CycleSet.OrderBy(x => x).LastOrDefault();

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

