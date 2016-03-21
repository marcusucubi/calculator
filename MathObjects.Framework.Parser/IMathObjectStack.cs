using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathObjectStack
    {
        event EventHandler<MathObjectStackArgs> StackChanged;

        IMathObject Push(IMathObject mathObject);

        IMathObject Push(IMathOperation op);

        IMathObject Pop();

        void Clear();

        IMathObject[] Peek(int size);

        IMathObject Peek();

        IMathObject Top { get; }

        int Size { get; }
    }
}

