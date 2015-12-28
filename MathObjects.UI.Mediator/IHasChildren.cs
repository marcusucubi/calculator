using System;
using MathObjects.Framework;

namespace MathObjects.UI.Mediator
{
    public interface IHasChildren
    {
        IMathObject[] Children
        {
            get;
        }
    }
}

