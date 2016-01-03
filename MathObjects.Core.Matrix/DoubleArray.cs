using System;
using System.Collections.Generic;

namespace MathObjects.Core.Matrix
{
	class DoubleArray<T> 
	{
		readonly int width;
		
		readonly int height;
		
		readonly IDictionary<string, T> dictionary = 
			new Dictionary<string, T>();
		
		public DoubleArray(DoubleArray<T> clone)
		{
			this.width = clone.width;
			this.height = clone.height;
			
			for(int x = 0; x < width; x++)
			{
				for(int y = 0; y < height; y++)
				{
					string key = GenKey(y, x);
					this.dictionary[key] = clone.dictionary[key];
				}
			}
		}
		
		public DoubleArray(int width, int height)
		{
			this.width = width;
			this.height = height;
			
			for(int x = 0; x < width; x++)
			{
				for(int y = 0; y < height; y++)
				{
					string key = GenKey(y, x);
					this.dictionary[key] = default(T);
				}
			}
		}
		
		public int Height
		{
			get { return this.height; }
		}
		
		public int Width
		{
			get { return this.width; }
		}
		
		public T this[int row, int col]
		{
			get 
			{ 
				return this.dictionary[GenKey(row,col)]; 
			}
			set 
			{
				var key = GenKey(row,col);
				
				if (!dictionary.ContainsKey(key))
				{
					throw new Exception(key + " not in dictionary");
				}
				
				this.dictionary[key]=value; 
			}
		}
		
		string GenKey(int row, int col)
		{
			return "[" + row + "," + col + "]";
		}
		
		public override bool Equals(object obj)
		{
			var s1 = GenFullKey();
			var s2 = (obj as DoubleArray<T>).GenFullKey();
			return (s1 == s2);
		}
		
		public override int GetHashCode()
		{
			return GenFullKey().GetHashCode();
		}
		
		string GenFullKey()
		{
			string s = "";
			foreach(var i in this.dictionary)
			{
				s += i.Key + i.Value;
			}
			
			return s;
		}
	}
}
