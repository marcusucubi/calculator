using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathObjectStack
    {
        event EventHandler<MathObjectStackArgs> StackChanged;

        void Push(IMathObject mathObject);

        void Push(IMathOperation op);

        IMathObject Pop();

        void Clear();

        IMathObject[] Peek(int size);

        IMathObject Top { get; }

        int Size { get; }
    }
}

