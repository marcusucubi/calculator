using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Core.Matrix
{
	public struct PlaceHolder<T> : IHasOperation<PlaceHolder<T>>
	{
		static public PlaceHolder<T> IDENTITY = new PlaceHolder<T>(true, false);
		
		static public PlaceHolder<T> ZERO = new PlaceHolder<T>(false, true);
		
		ReadOnlyCollection<T> subjectList;
		
		bool isIdentity;
		
		bool isNotZero;
		
		public PlaceHolder(T subject)
		{
			var list = new List<T>();
			list.Add(subject);
			this.subjectList = list.AsReadOnly();
			this.isIdentity = false;
			this.isNotZero = true;
		}

		public PlaceHolder(
			PlaceHolder<T> p1,
			PlaceHolder<T> p2)
		{
			var list = new List<T>();
			list.AddRange(p1.SubjectList);
			list.AddRange(p2.SubjectList);
			this.subjectList = list.AsReadOnly();
			this.isIdentity = false;
			this.isNotZero = true;
		}
		
		internal PlaceHolder(bool isIdentity, bool isZero)
		{
			subjectList = new ReadOnlyCollection<T>(new List<T>());
			this.isIdentity = isIdentity;
			this.isNotZero = !isZero;
		}
		
		public ReadOnlyCollection<T> SubjectList
		{
			get 
			{ 
				if (subjectList == null)
				{
					subjectList = new List<T>().AsReadOnly();
				}
				
				return subjectList; 
			}
		}
		
		public bool IsIdentity
		{
			get { return isIdentity; }
		}
		
		public bool IsZero
		{
			get { return !isNotZero; }
		}
		
		public PlaceHolder<T> MultipyBy(PlaceHolder<T> other)
		{
			if (other.IsIdentity)
			{
				return this;
			}
			
			if (this.IsIdentity)
			{
				return other;
			}
			
			if (other.IsZero || this.IsZero)
			{
				return new PlaceHolder<T>();
			}
			
			return new PlaceHolder<T>(this, other);
		}

		public PlaceHolder<T> Add(PlaceHolder<T> other)
		{
			if (other.IsZero)
			{
				return this;
			}
			
			if (this.IsZero)
			{
				return other;
			}
			
			if (other.IsIdentity || this.IsIdentity)
			{
				throw new Exception("Can not add IDENTITY");
			}
			
			return new PlaceHolder<T>(this, other);
		}
		
		public override string ToString()
		{
			if (this.IsIdentity)
			{
				return "{IDENTITY}";
			}
			
			if (this.IsZero)
			{
				return "{ZERO}";
			}
			
			string s = "{";
			foreach(var o in SubjectList)
			{
				s += o + " ";
			}
			
			return s + "}";
		}
	}
}
