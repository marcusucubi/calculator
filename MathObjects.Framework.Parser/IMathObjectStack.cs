using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathObjectStack
    {
        event EventHandler<MathObjectStackArgs> StackChanged;

        void Push(IMathObject mathObject);

        void Push(IMathBinaryOperation op);

        void Push(IMathOperation op);

        IMathObject Pop();

        void Clear();

        IMathObject Top { get; }
    }
}

