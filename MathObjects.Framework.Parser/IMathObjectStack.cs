using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathObjectStack
    {
        void Enter(IMathObject mathObject);

        void Perform(IMathBinaryOperation op);

        void Perform(IMathOperation op);

        IMathObject Top { get; }
    }
}

