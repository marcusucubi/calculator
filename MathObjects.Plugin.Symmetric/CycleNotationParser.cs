using System;
using System.Collections.Generic;
using System.Linq;

namespace MathObjects.Plugin.Symmetric
{
    public static class CycleNotationParser
    {
        static public PermutationMatix Parse(string value)
        {
            var del = new char[]{ '(', ')', ' ' };
            string clean = value.Trim(del);
            string[] dirtyParts = clean.Split(' ');

            if (dirtyParts.Length == 1)
            {
                return new PermutationMatix(PermutationMatix.GetIdentity(3));
            }

            var parts = new List<int>();
            foreach (var part in dirtyParts)
            {
                int i = int.Parse(part);
                parts.Add(i);
            }

            var moves = BuildMoves(parts);

            var list = BuildSet(parts);

            var output = DoMoves(moves, list);

            return PermutationMatix.Create(output.ToArray());
        }

        static List<Tuple<int, int>> BuildMoves(List<int> parts)
        {
            var moves = new List<Tuple<int, int>>();
            {
                var lastTwo = new List<int>();
                foreach (var part in parts)
                {
                    lastTwo.Add(part);

                    if (lastTwo.Count >= 2)
                    {
                        var move = new Tuple<int, int>(lastTwo[0], lastTwo[1]);
                        moves.Add(move);

                        lastTwo.RemoveAt(0);
                    }
                }

                {
                    int first = parts.FirstOrDefault();
                    int last = parts.LastOrDefault();

                    var move = new Tuple<int, int>(last, first);

                    moves.Add(move);
                }
            }

            return moves;
        }

        static List<int> BuildSet(List<int> parts)
        {
            var list = new List<int>();

            int last = parts.OrderBy(x => x).LastOrDefault();
            for (int i = 0; i < last; i++)
            {
                list.Add(i + 1);
            }

            return list;
        }

        static List<int> DoMoves(List<Tuple<int, int>> moves, List<int> list)
        {
            var output = list.ToList();

            foreach(var move in moves)
            {
                Move(list, output, move.Item1, move.Item2);
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

