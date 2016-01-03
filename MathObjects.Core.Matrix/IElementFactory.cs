using System;

namespace MathObjects.Core.Matrix
{
	public interface IElementFactory<T>
	{
		T GetMultiplicativeIdentity();
		
		T GetAdditiveIdentity();
	}
}
