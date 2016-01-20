using System;

namespace MathObjects.Framework.Parser
{
    public interface IHasParser
    {
        IParser Parser { get; }
    }
}

