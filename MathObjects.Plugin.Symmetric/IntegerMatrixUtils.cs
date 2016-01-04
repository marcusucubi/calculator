using System;
using MathObjects.Core.Matrix;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public delegate void MatrixAction(RowVector<IntegerWithOperation> row, int index);

    public static class IntegerMatrixUtils
    {
        public static IntegerMatrix Multiply(
            this List<IntegerMatrix> array,
            IntegerMatrix matrix)
        {
            IntegerMatrix result = new IntegerMatrix(matrix);

            for (int i = 0; i < array.Count; i++)
            {
                var temp = array[i].MultiplyBy(result);

                result = new IntegerMatrix(temp);
            }

            return result;
        }

        public static void ForEach(this IntegerMatrix matrix, MatrixAction action)
        {
            for (int i = 0; i < matrix.Height; i++)
            {
                var row = matrix.Rows[i];
                action.Invoke(row, i);
            }
        }

        public static int FindIndex(this IntegerMatrix matrix, int indexToFind)
        {
            int result = 0;

            foreach (var row in matrix.Rows)
            {
                int index = row.Index();
                if (index == indexToFind)
                {
                    break;
                }

                result++;
            }

            return result;
        }

        public static int Index(this RowVector<IntegerWithOperation> row)
        {
            int result = 0;

            for (int i = 0; i < row.Width; i++)
            {
                var intWith = row[i];
                if (intWith.Equals(1))
                {
                    break;
                }

                result++;
            }

            return result;
        }

        public static void SwitchRow(this IntegerMatrix m, int index1, int index2)
        {
            if (index1 >= m.Rows.Count)
            {
                throw new ArgumentException();
            }

            if (index2 >= m.Rows.Count)
            {
                throw new ArgumentException();
            }

            var row1 = m.Rows[index1] as RowVector<IntegerWithOperation>;
            var row2 = m.Rows[index2] as RowVector<IntegerWithOperation>;

            SetRow(m, index2, row1);
            SetRow(m, index1, row2);
        }

        public static IntegerMatrix CreateRowSwitchMatrix(
            this IntegerMatrix m, int index1, int index2)
        {
            if (index1 >= m.Rows.Count)
            {
                throw new ArgumentException();
            }

            if (index2 >= m.Rows.Count)
            {
                throw new ArgumentException();
            }

            var result = IntegerMatrix.GetIdentity(m.Height);

            var row1 = result.Rows[index1] as RowVector<IntegerWithOperation>;
            var row2 = result.Rows[index2] as RowVector<IntegerWithOperation>;

            SetRow(result, index2, row1);
            SetRow(result, index1, row2);

            return result;
        }


        static void SetRow(
            IntegerMatrix m,
            int index, 
            RowVector<IntegerWithOperation> row)
        {
            for (int i = 0; i < m.Width; i++)
            {
                m[index, i] = row[i].Value;
            }
        }
    }
}

