using System;
using MathObjects.Core.Extension;

namespace MathObjects.Framework
{
    public interface IMathOperation : IExtensionableObject
    {
        IMathObject Perform(IMathObject[] target);

        int NumberOfParameters { get; }

        string Symbol { get; }
    }
}

