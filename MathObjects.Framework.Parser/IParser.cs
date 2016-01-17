using System;
using MathObjects.Framework.Registry;

namespace MathObjects.Framework.Parser
{
    public interface IParser
    {
        void Parse(string data, IMathObjectStack stack, FactoryRegistry registry);
    }
}

