using System;

namespace MathObjects.Core.Matrix
{
    public class IntegerRowVector : RowVector<IntegerWithOperation>
    {
        public IntegerRowVector(int size)
            : base(size)
        {
        }

        public IntegerRowVector(IntegerRowVector clone)
            : base(clone)
        {
        }

        public IntegerRowVector(int[] array)
            : base(array.Length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this[i] = array[i];
            }
        }

        public new int this [int index]
        {
            get { return base[0, index].Value; }
            set { base[0, index] = new IntegerWithOperation(value); }
        }

        public int MultiplyBy(IntegerVector vector)
        {
            var result = base.MultiplyBy(vector);
            return result.Value;
        }
    }
}
