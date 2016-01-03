using System;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class DoubleArrayTest
	{
		[Test]
		public void TestMethod()
		{
			var a = new DoubleArray<string>(3,3);
			for(int x = 0; x < a.Width; x++)
			{
				for(int y = 0; y < a.Height; y++)
				{
					a[x,y] = "[" + x + "," + y + "]";
				}
			}
			
			for(int x = 0; x < a.Width; x++)
			{
				for(int y = 0; y < a.Height; y++)
				{
					string test = a[x,y];
					Assert.AreEqual("[" + x + "," + y + "]", test);
				}
			}
		}
		
		[Test]
		public void TestMethod2()
		{
			var a = new DoubleArray<string>(1,3);
			
			bool ok = true;
			try
			{
				a[2,2] = "6";
			}
			catch(Exception)
			{
				ok = false;
			}
			
			Assert.False(ok);
		}
		
		[Test]
		public void TestMethod3()
		{
			var a = new DoubleArray<string>(3,3);
			var b = new DoubleArray<string>(3,3);
			for(int x = 0; x < a.Width; x++)
			{
				for(int y = 0; y < a.Height; y++)
				{
					string s = "[" + x + "," + y + "]";
					a[x,y] = s;
					b[x,y] = s;
				}
			}
			
			Assert.AreEqual(a, b);
			Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
		}
	}
}
