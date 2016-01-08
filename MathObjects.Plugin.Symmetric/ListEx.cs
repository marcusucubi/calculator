using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public static class ListEx
    {
        public static List<int> DoMoves(this List<int> list, List<Move> moves)
        {
            var output = list.ToList();

            foreach(var move in moves)
            {
                Move(list, output, move.From, move.To);
            }

            return output;
        }

        static void Move(List<int> list, List<int> output, int from, int to)
        {
            int v1 = list[from - 1];
            output[to - 1] = v1;
        }
    }
}

