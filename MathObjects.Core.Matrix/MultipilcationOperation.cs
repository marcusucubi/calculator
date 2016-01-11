using System;

namespace MathObjects.Core.Matrix
{
    class MultipilcationOperation<T> where T : IHasOperation<T>
    {
        readonly Matrix<T> leftMatrix;
		
        readonly Matrix<T> rightMatrix;

        public MultipilcationOperation(
            Matrix<T> leftMatrix, 
            Matrix<T> rightMatrix)
        {
            this.leftMatrix = leftMatrix;
            this.rightMatrix = rightMatrix;
			
            if (leftMatrix.Width != rightMatrix.Height)
            {
                throw new Exception("leftMatrix.Width != rightMatrix.Height");
            }
        }

        public Matrix<T> Execute()
        {
            var result = new Matrix<T>(
                    this.rightMatrix.Width,
                    this.leftMatrix.Height);
			
            for (int row = 0; row < this.leftMatrix.Height; row++)
            {
                for (int col = 0; col < this.rightMatrix.Width; col++)
                {
                    Multiply(result, row, col);
                }
            }
			
            return result;
        }

        public void Multiply(Matrix<T> result, int row, int col)
        {
            T sum = default(T);
			
            for (int i = 0; i < this.leftMatrix.Width; i++)
            {
                var left = leftMatrix[row, i];
                var right = rightMatrix[i, col];
				
                var temp = left.MultipyBy(right);
				
                sum = sum.Add(temp);
            }
			
            result[row, col] = sum;
        }
    }
}
