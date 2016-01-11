using System;

namespace MathObjects.Core.Matrix
{
    public class IntegerVector : Vector<IntegerWithOperation>
    {
        public IntegerVector(int size)
            : base(size)
        {
        }

        public IntegerVector(IntegerVector clone)
            : base(clone)
        {
        }

        public IntegerVector(int[] array)
            : base(array.Length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this[i] = array[i];
            }
        }

        public new int this [int index]
        {
            get { return base[index, 0].Value; }
            set { base[index, 0] = new IntegerWithOperation(value); }
        }
    }
}
