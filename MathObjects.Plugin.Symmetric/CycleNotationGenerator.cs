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
            var smallSwitches = new List<int>();
            int index = 0;
            foreach(var pos in switches)
            {
                if (pos != index + 1)
                {
                    smallSwitches.Add(pos);
                }

                index++;
            }

            var list = Order(smallSwitches);
//            var list = switches;
            
            string s = "(";
            foreach(var pos in list)
            {
                s += " " + pos;
            }
            s += " )";

            return s;
        }

        static IEnumerable<int> Order(List<int> switches)
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

