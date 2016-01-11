using System;

namespace MathObjects.Core.Matrix
{
    public class Vector<T> : Matrix<T>
        where T : IHasOperation<T>
    {
        public Vector(T[] array)
            : base(1, array.Length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this[i] = array[i];
            }
        }

        public Vector(Vector<T> clone)
            : base(clone)
        {
        }

        public Vector(Matrix<T> clone)
            : base(clone)
        {
        }

        public Vector(int size)
            : base(1, size)
        {
        }

        public T this [int index]
        {
            get { return base[index, 0]; }
            set { base[index, 0] = value; }
        }

        public override string ToString()
        {
            string s = "[";
            for (int i = 0; i < this.Height; i++)
            {
                s += this[i] + " ";
            }
            return s + "]";
        }
    }
}
