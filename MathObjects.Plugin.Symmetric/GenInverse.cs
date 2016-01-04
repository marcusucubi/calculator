using System;
using System.Collections.Generic;
using System.Linq;
using MathObjects.Core.Matrix;

namespace MathObjects.Plugin.Symmetric
{
    public class GenInverse
    {
        readonly List<IntegerMatrix> array = new List<IntegerMatrix>();

        public List<IntegerMatrix> ElementaryArray
        {
            get { return this.array; }
        }

        public int Generate(IntegerMatrix input)
        {
            var matrix = new IntegerMatrix(input);

            var copy = new IntegerMatrix(matrix);

            copy.ForEach((row, i) => 
                {
                    if (i != row.Index())
                    {
                        var inter = array.Multiply(copy);

                        int indexToSwitch = inter.FindIndex(i);

                        if (indexToSwitch != i)
                        {
                            var el = copy.CreateRowSwitchMatrix(indexToSwitch, i);

                            array.Add(el);
                        }
                    }
                }
            );

            return array.Count;
        }
    }
}

