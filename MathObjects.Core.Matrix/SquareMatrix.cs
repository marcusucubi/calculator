using System;

namespace MathObjects.Core.Matrix
{
	public class SquareMatrix<T> : Matrix<T>
		where T : IHasOperation<T>
	{
		public static SquareMatrix<T> GetIdentity(
			IElementFactory<T> factory, 
			int size)
		{
			var result = new SquareMatrix<T>(size);
			var identity = factory.GetMultiplicativeIdentity();
			
			for(int i = 0; i < size; i++)
			{
				result[i, i] = identity;
			}
			
			return result;
		}
		
		public SquareMatrix(SquareMatrix<T> clone)
			: base(clone)
		{
		}
		
		public SquareMatrix(Matrix<T> clone)
			: base(clone)
		{
		}
		
		public SquareMatrix(int size)
			: base(size, size)
		{
		}
		
		public SquareMatrix<T> MultiplyBy(SquareMatrix<T> other)
		{
			return new SquareMatrix<T>(base.MultiplyBy(other));
		}
	}
}
