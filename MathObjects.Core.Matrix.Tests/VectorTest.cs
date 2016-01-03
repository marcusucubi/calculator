using System;
using System.Diagnostics;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class VectorTest
	{
		[Test]
		public void TestMethod()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			var row = new IntegerRowVector(new int[] {3, 2, 1} );
			
			int test = row.MultiplyBy(vector);
			
			Assert.AreEqual(10, test);
		}
		
		[Test]
		public void TestMethod2()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			var id = IntegerMatrix.GetIdentity(3);
			
			var test = id.MultiplyBy(vector);
			
			Assert.True(vector.Equals(test));
		}
		
		[Test]
		public void TestMethod3()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			var row = new IntegerRowVector(new int[] {3, 2, 1} );
			
			var test = row.MultiplyBy(vector);
			
			Assert.AreEqual(10, test);
		}
		
		[Test]
		public void TestMethod4()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			var row = new IntegerRowVector(new int[] {3, 2, 1} );
			
			var test = vector.MultiplyBy(row);
			
			Assert.AreEqual(3, test.Height);
			Assert.AreEqual(3, test.Width);
		}
		
		[Test]
		public void TestMethod5()
		{
			var m1 = new Matrix<IntegerWithOperation>(2, 3);
			var m2 = new Matrix<IntegerWithOperation>(4, 5);
			
			bool ok = true;
			try
			{
				m1.MultiplyBy(m2);
			}
			catch(Exception)
			{
				ok = false;
			}
			
			Assert.False(ok);
		}
		
		[Test]
		public void TestMethod6()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			
			vector[0] = 3;
			vector[2] = 1;
			
			Assert.AreEqual(3, vector[0]);
			Assert.AreEqual(1, vector[2]);
			
			Debug.WriteLine(vector);
		}
		
		[Test]
		public void TestMethod7()
		{
			var vector = new IntegerRowVector(new int[] {1, 2, 3} );
			
			vector[0] = 3;
			vector[2] = 1;
			
			Assert.AreEqual(3, vector[0]);
			Assert.AreEqual(1, vector[2]);
			Debug.WriteLine(vector);
		}
		
		[Test]
		public void TestMethod8()
		{
			var vector = new IntegerVector(new int[] {1, 2, 3} );
			var row = new IntegerRowVector(new int[] {1, 2, 3} );
			vector[0] = 1;
			
			var m = vector.MultiplyBy(row);;
			
			Assert.AreEqual(1, m[0,0].Value);
			Assert.AreEqual(4, m[1,1].Value);
			Assert.AreEqual(9, m[2,2].Value);
		}
		
		[Test]
		public void TestMethod9()
		{
			var vector = new Vector<IntegerWithOperation>(2);
			
			vector[0] = new IntegerWithOperation(1);
			Assert.AreEqual(1, vector[0].Value);
		}
	}
}
