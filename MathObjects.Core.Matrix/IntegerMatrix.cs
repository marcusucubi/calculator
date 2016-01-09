using System;

namespace MathObjects.Core.Matrix
{
	public class IntegerMatrix : SquareMatrix<IntegerWithOperation>
	{
		public static IntegerMatrix GetIdentity(int size)
		{
			var factory = new IntegerWithOperationFactory();
			var id = SquareMatrix<IntegerWithOperation>.GetIdentity(factory, size);
			
			return new IntegerMatrix(id);
		}
		
		public IntegerMatrix(int size)
			: base(size)
		{
		}
		
		public IntegerMatrix(SquareMatrix<IntegerWithOperation> clone)
			: base(clone)
		{
		}
		
		public new int this[int row, int col]
		{
			get { return base[row,col].Value; }
			set { base[row,col]=new IntegerWithOperation(value); }
		}
	}
}
