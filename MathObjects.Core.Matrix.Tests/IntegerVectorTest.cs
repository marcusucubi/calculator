using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class IntegerVectorTest
	{
		[Test]
		public void TestMethod()
		{
			var v = new IntegerVector(3);
			
			Assert.AreEqual(3, v.Height);
		}
		
		[Test]
		public void TestMethod2()
		{
			var v = new IntegerVector(3);
			v[0] = 1;
			
			var v2 = new IntegerVector(v);
			
			Assert.AreEqual(3, v2.Height);
			Assert.AreEqual(1, v2[0]);
		}
	}
}
