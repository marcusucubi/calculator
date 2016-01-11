using System;

namespace MathObjects.Core.Matrix
{
    public class RowVector<T> : Matrix<T>
        where T : IHasOperation<T>
    {
        public RowVector(T[] array)
            : base(array.Length, 1)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this[i] = array[i];
            }
        }

        public RowVector(RowVector<T> clone)
            : base(clone)
        {
        }

        public RowVector(Matrix<T> clone)
            : base(clone)
        {
        }

        public RowVector(int size)
            : base(size, 1)
        {
        }

        public T this [int index]
        {
            get { return base[0, index]; }
            set { base[0, index] = value; }
        }

        public T MultiplyBy(Vector<T> other)
        {
            var result = base.MultiplyBy(other);
            return result[0, 0];
        }

        public override string ToString()
        {
            string s = "[";
            for (int i = 0; i < this.Width; i++)
            {
                s += this[i] + " ";
            }
            return s + "]";
        }
    }
}
