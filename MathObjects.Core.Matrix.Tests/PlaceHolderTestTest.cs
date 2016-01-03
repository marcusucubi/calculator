using System;
using System.Diagnostics;
using NUnit.Framework;

namespace MathObjects.Core.Matrix.Tests
{
	[TestFixture]
	public class PlaceHolderTestTest
	{
		[Test]
		public void TestMethod()
		{
			var v = new Vector<PlaceHolder<string>>(3);
			v[0] = new PlaceHolder<string>("a");
			v[1] = new PlaceHolder<string>("b");
			v[2] = new PlaceHolder<string>("c");
			
			var id = new Matrix<PlaceHolder<string>>(3,3);
			id.ForEach((row, col, data, matrix) => { matrix[row,col] = PlaceHolder<string>.ZERO; });
				
			id[0,2] = PlaceHolder<string>.IDENTITY;
			id[1,1] = PlaceHolder<string>.IDENTITY;
			id[2,0] = PlaceHolder<string>.IDENTITY;
			
			var r = id.MultiplyBy(v) as Vector<PlaceHolder<string>>;
			
			Assert.AreEqual("c", r[0].SubjectList[0]);
			Assert.AreEqual("b", r[1].SubjectList[0]);
			Assert.AreEqual("a", r[2].SubjectList[0]);
		}
		
		[Test]
		public void TestMethod2()
		{
			var array = new PlaceHolder<string>[]
			{
				new PlaceHolder<string>("a"),
				new PlaceHolder<string>("b"),
				new PlaceHolder<string>("c")
			};
			var v = new Vector<PlaceHolder<string>>(array);
			
			var zero = new Matrix<PlaceHolder<string>>(3,3);
			
			var r = zero.MultiplyBy(v) as Vector<PlaceHolder<string>>;
			
			Assert.True(r[0].SubjectList.Count == 0);
		}
		
		[Test]
		public void TestMethod3()
		{
			var array = new PlaceHolder<string>[]
			{
				new PlaceHolder<string>("a"),
				new PlaceHolder<string>("b"),
				new PlaceHolder<string>("c")
			};
			var v = new Vector<PlaceHolder<string>>(array);
			var r = new RowVector<PlaceHolder<string>>(array);
			
			var result = r.MultiplyBy(v);
			
			Assert.True(result.SubjectList.Count == 6);
		}
		
		[Test]
		public void TestMethod4()
		{
			var array = new PlaceHolder<string>[]
			{
				new PlaceHolder<string>("a"),
				new PlaceHolder<string>("b"),
				new PlaceHolder<string>("c")
			};
			var v = new Vector<PlaceHolder<string>>(array);
			Debug.WriteLine(v);
			
			Debug.WriteLine(PlaceHolder<string>.IDENTITY);
			Debug.WriteLine(PlaceHolder<string>.ZERO);
		}
		
		[Test]
		public void TestMethod5()
		{
			var array = new PlaceHolder<string>[]
			{
				new PlaceHolder<string>("a"),
				new PlaceHolder<string>("b"),
				new PlaceHolder<string>("c")
			};
			var v = new Vector<PlaceHolder<string>>(array);
			var r = new RowVector<PlaceHolder<string>>(3);
			
			var result = r.MultiplyBy(v);
			
			Assert.True(result.SubjectList.Count == 0);
			
			var result2 = v.MultiplyBy(r);
			
			Assert.True(result2.Width == 3);
		}
		
		[Test]
		public void TestMethod6()
		{
			var v = new Vector<PlaceHolder<string>>(3);
			var r = new RowVector<PlaceHolder<string>>(3);
			
			v.ForEach( (row, col, data, matrix) => matrix[row, col] = PlaceHolder<string>.IDENTITY);
			r.ForEach( (row, col, data, matrix) => matrix[row, col] = PlaceHolder<string>.IDENTITY);
			
			bool ok = true;
			try
			{
				r.MultiplyBy(v);
			}
			catch(Exception)
			{
				ok = false;
			}
			
			Assert.False(ok);
		}
	}
}
