using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathObjectStack
    {
        void Push(IMathObject mathObject);

        void Push(IMathBinaryOperation op);

        void Push(IMathOperation op);

        IMathObject Top { get; }
    }
}

