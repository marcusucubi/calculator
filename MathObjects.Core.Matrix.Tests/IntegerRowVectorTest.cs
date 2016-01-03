using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class IntegerRowVectorTest
	{
		[Test]
		public void TestMethod()
		{
			var v = new IntegerRowVector(3);
			
			Assert.AreEqual(3, v.Width);
		}
		
		[Test]
		public void TestMethod2()
		{
			var v = new IntegerRowVector(3);
			v[0] = 1;
			
			var v2 = new IntegerRowVector(v);
			
			Assert.AreEqual(3, v2.Width);
			Assert.AreEqual(1, v2[0]);
		}
	}
}
