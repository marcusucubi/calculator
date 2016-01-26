using System;
using MathObjects.Framework;

namespace MathObjects.Framework.Parser
{
    public interface IHasChildren
    {
        IMathObject[] Children
        {
            get;
        }
    }
}

