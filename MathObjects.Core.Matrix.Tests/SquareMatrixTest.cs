using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class SquareMatrixTest
	{
		[Test]
		public void TestMethod()
		{
			var matrix = new IntegerMatrix(3);
			
			int index = 0;
			for(int x = 0; x < matrix.Width; x ++)
			{
				for(int y = 0; y < matrix.Height; y ++)
				{
					matrix[x, y] = index;
					index++;
				}
			}
			
			index = 0;
			for(int x = 0; x < matrix.Width; x ++)
			{
				for(int y = 0; y < matrix.Height; y ++)
				{
					var test = matrix[x, y];
					Assert.AreEqual(index, test);
					index++;
				}
			}
		}
		
		[Test]
		public void TestMultiplication()
		{
			var matrix = GenTestMatrix(3);
			var id = IntegerMatrix.GetIdentity(3);
			
			var result = matrix.MultiplyBy(id);
			
			int index = 0;
			for(int x = 0; x < matrix.Width; x ++)
			{
				for(int y = 0; y < matrix.Height; y ++)
				{
					var test = result[x, y];
					Assert.AreEqual(index, test.Value);
					index++;
				}
			}
		}
		
		SquareMatrix<IntegerWithOperation> GenTestMatrix(int size)
		{
			var matrix = new SquareMatrix<IntegerWithOperation>(size);
			
			int index = 0;
			for(int x = 0; x < matrix.Width; x ++)
			{
				for(int y = 0; y < matrix.Height; y ++)
				{
					var value = new IntegerWithOperation(index);
					matrix[x, y] = value;
					index++;
				}
			}
			
			return matrix;
		}
	}
}
