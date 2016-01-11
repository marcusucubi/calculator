using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Core.Matrix
{
    public delegate void MatrixHandler<T>(int row,int col,T data,Matrix<T> matrix) where T : IHasOperation<T>;
	
    public class Matrix<T> where T : IHasOperation<T>
    {
        readonly DoubleArray<T> doubleArray;
		
        readonly int width;
		
        readonly int height;

        public Matrix(Matrix<T> clone)
        {
            this.width = clone.Width;
            this.height = clone.Height;
			
            doubleArray = new DoubleArray<T>(clone.doubleArray);
        }

        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
			
            doubleArray = new DoubleArray<T>(width, height);
        }

        public T this [int row, int col]
        {
            get { return this.doubleArray[row, col]; }
            set { this.doubleArray[row, col] = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public ReadOnlyCollection<RowVector<T>> Rows
        {
            get
            {  
                var result = new List<RowVector<T>>();
				
                for (int row = 0; row < Height; row++)
                {
                    var rowVector = new RowVector<T>(Width);
                    result.Add(rowVector);
					
                    for (int col = 0; col < Width; col++)
                    {
                        rowVector[col] = this[row, col];
                    }
                }
				
                return result.AsReadOnly();
            }
        }

        public void ForEach(MatrixHandler<T> hanlder)
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    T cell = this[row, col];
                    hanlder(row, col, cell, this);
                }
            }
        }

        public Matrix<T> MultiplyBy(Matrix<T> other)
        {
            var op = new MultipilcationOperation<T>(this, other);
            var result = op.Execute();
			
            if (result.Width == 1)
            {
                return new Vector<T>(result);
            }
            else if (result.Height == 1)
            {
                return new RowVector<T>(result);
            }
			
            return result;
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix<T>;
			
            if (this.Width != matrix.Width ||
            this.Height != matrix.Height)
            {
                return false;
            }
			
            bool result = true;
			
            for (int row = 0; row < matrix.Height; row++)
            {
                for (int col = 0; col < matrix.Width; col++)
                {
                    if (!this[row, col].Equals(matrix[row, col]))
                    {
                        result = false;
                        break;
                    }
                }
            }
			
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string s = "[";
			
            foreach (var row in Rows)
            {
                s += " " + row + "";
            }
			
            return s + "]";
        }
    }
}
