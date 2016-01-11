using System;

namespace MathObjects.Core.Matrix
{
    public class IntegerWithOperationFactory : IElementFactory<IntegerWithOperation>
    {
        public IntegerWithOperation GetMultiplicativeIdentity()
        {
            return new IntegerWithOperation(1);
        }

        public IntegerWithOperation GetAdditiveIdentity()
        {
            return new IntegerWithOperation(0);
        }
    }
}
