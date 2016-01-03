using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class IntegerWithOperationFactoryTest
	{
		[Test]
		public void TestMethod()
		{
			var f = new IntegerWithOperationFactory();
			var i2 = new IntegerWithOperation(2);
			
			var e = f.GetAdditiveIdentity();
			
			Assert.AreEqual(i2.Add(e).Value, i2.Value);
		}
		
		[Test]
		public void TestMethod2()
		{
			var f = new IntegerWithOperationFactory();
			var i2 = new IntegerWithOperation(2);
			
			var e = f.GetMultiplicativeIdentity();
			
			Assert.AreEqual(i2.MultipyBy(e).Value, i2.Value);
		}
	}
}
