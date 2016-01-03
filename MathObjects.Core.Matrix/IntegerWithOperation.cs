
namespace MathObjects.Core.Matrix
{
	public struct IntegerWithOperation : IHasOperation<IntegerWithOperation>
	{
		readonly int value;
		
		public IntegerWithOperation(int value)
		{
			this.value = value;
		}
		
		public int Value
		{
			get { return this.value; }
		}

		public IntegerWithOperation MultipyBy(IntegerWithOperation other)
		{
			return new IntegerWithOperation(this.value * other.Value);
		}
		
		public IntegerWithOperation Add(IntegerWithOperation other)
		{
			return new IntegerWithOperation(this.value + other.Value);
		}
		
		public override bool Equals(object obj)
		{
			if (obj is IntegerWithOperation)
			{
				return (this.Value == ((IntegerWithOperation)obj).Value);
			}
			
            if (obj is int)
            {
                return (this.Value == (int)obj);
            }

			return false;
		}
		
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		} 
		
		public override string ToString()
		{
			return "" + value;
		}
	}
}
