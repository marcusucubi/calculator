using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class IntegerWithOperationTest
	{
		[Test]
		public void TestMethod()
		{
			var i1 = new IntegerWithOperation(1);
			var i2 = new IntegerWithOperation(1);
			
			Assert.AreEqual(i1, i2);
			
			Assert.AreEqual(i1.GetHashCode(), i2.GetHashCode());
		}
		
		[Test]
		public void TestMethod2()
		{
			var i1 = new IntegerWithOperation(1);
			
            Assert.AreEqual(i1, 1);
		}
	}
}
