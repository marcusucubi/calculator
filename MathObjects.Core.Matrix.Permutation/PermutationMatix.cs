using System;
using MathObjects.Core.Matrix;

namespace MathObjects.Core.Matrix.Permutation
{
    public class PermutationMatix : IntegerMatrix
    {
        public PermutationMatix(SquareMatrix<IntegerWithOperation> clone)
            : base(clone)
        {
        }

        public PermutationMatix(int size)
            : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                this[i, i] = 1;
            }
        }

        public static PermutationMatix Create(int[] array)
        {
            var result = new PermutationMatix(array.Length);
			
            for (int row = 0; row < result.Height; row++)
            {
                int columnValue = array[row];
                for (int col = 0; col < result.Width; col++)
                {
                    result[row, col] = (col + 1 == columnValue) ? 1 : 0;
                }
            }
			
            return result;
        }

        public void Switch(int index1, int index2)
        {
            if (index1 >= this.Rows.Count)
            {
                throw new ArgumentException();
            }
			
            if (index2 >= this.Rows.Count)
            {
                throw new ArgumentException();
            }
			
            var row1 = this.Rows[index1] as RowVector<IntegerWithOperation>;
            var row2 = this.Rows[index2] as RowVector<IntegerWithOperation>;
			
            SetRow(index2, row1);
            SetRow(index1, row2);
        }

        public void SetRow(int index, RowVector<IntegerWithOperation> row)
        {
            for (int i = 0; i < this.Width; i++)
            {
                this[index, i] = row[i].Value;
            }
        }

        public int[] Switches
        {
            get
            {
                var result = new int[this.Height];
                int index = 0;
                foreach (var row in this.Rows)
                {
                    for (int i = 0; i < row.Width; i++)
                    {
                        if (row[i].Value == 1)
                        {
                            result[index] = i + 1;
                            break;
                        }
                    }
					
                    index++;
                }
				
                return result;
            }
        }

        public PermutationMatix MultiplyBy(PermutationMatix other)
        {
            return new PermutationMatix(base.MultiplyBy(other));
        }

        public int FindIndex(int index)
        {
            int result = -1;
			
            int rowIndex = 0;
            foreach (var row in this.Rows)
            {
                int count = 0;
                for (int i = 0; i < row.Width; i++)
                {
                    if (row[i].Value == 1)
                    {
                        break;
                    }
					
                    count++;
                }
				
                if (count == index)
                {
                    result = rowIndex;
                    break;
                }
				
                rowIndex++;
            }
			
            return result;
        }
    }
}
