using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public static class CycleNotationGenerator
    {
        static public string Generate(PermutationMatix matrix)
        {
            var switches = matrix.Switches;
            //var list = Order(switches);
            var list = switches;

            string s = "(";
            int index = 0;

            foreach(var pos in list)
            {
                if (pos != index + 1)
                {
                    s += " " + pos;
                }

                index++;
            }

            s += " )";

            return s;
        }

        static IEnumerable<int> Order(int[] switches)
        {
            var list = new LinkedList<int>(switches);

            int min = switches.Min();
            while (list.First.Value != min)
            {
                Rotate(list);
            }

            return list;
        }

        static void Rotate(LinkedList<int> list)
        {
            int first = list.First.Value;
            list.RemoveFirst();
            list.AddLast(first);
        }
    }
}

