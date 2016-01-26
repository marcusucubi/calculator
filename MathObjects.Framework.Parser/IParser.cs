using System;

namespace MathObjects.Framework.Parser
{
    public interface IParser
    {
        void Parse(string data, IMathObjectStack stack);

        bool HasError { get; }
    }
}

