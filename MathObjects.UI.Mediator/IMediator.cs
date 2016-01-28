using System;
using MathObjects.Framework;
using System.Collections.Generic;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    public interface IMediator : IMathObjectStack 
    {
        Stack<IMathObject> ObjectStack { get; }

        void Enter(string input);
    }
}

