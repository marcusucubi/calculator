using System;
using System.Diagnostics;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class MatrixTest
	{
		[Test]
		public void TestMethod()
		{
			var m1 = new IntegerMatrix(2);
			var m2 = new IntegerMatrix(2);
			
			Assert.AreEqual(m1, m2);
		}
		
		[Test]
		public void TestMethod2()
		{
			var m1 = new IntegerMatrix(2);
			m1[0,0] = 2;
			m1[1,1] = 2;
			
			var v2 = new IntegerRowVector(2);
			
			var result = v2.MultiplyBy(m1);
			Assert.AreEqual(1, result.Height);
			Assert.AreEqual(2, result.Width);
		}
		
		[Test]
		public void TestMethod3()
		{
			var m1 = new IntegerMatrix(2);
			m1[0,0] = 2;
			m1[1,1] = 2;
			
			var r1 = m1.Rows[0];
			var r2 = m1.Rows[1];
			
			Assert.AreEqual(2, r1[0].Value);
			Assert.AreEqual(0, r2[0].Value);
		}
		
		[Test]
		public void TestMethod4()
		{
			var m1 = new IntegerMatrix(2);
			var m2 = new IntegerMatrix(4);
			
			Debug.WriteLine(m1);
			
			Assert.False(m1.Equals(m2));
		}
		
		[Test]
		public void TestMethod5()
		{
			var m1 = new IntegerMatrix(2);
			var m2 = new IntegerMatrix(4);
			
			Assert.False(m1.GetHashCode() == m2.GetHashCode());
		}
		
		[Test]
		public void TestMethod6()
		{
			var m1 = new IntegerMatrix(2);
			var m2 = new IntegerMatrix(2);
			m1[0,0] = 1;
			
			Assert.False(m1.Equals(m2));
		}
	}
}
