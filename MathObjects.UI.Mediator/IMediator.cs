using System;
using MathObjects.Framework;
using System.Collections.Generic;
using MathObjects.Framework.Parser;

namespace MathObjects.UI.Mediator
{
    public class MediatorArgs : EventArgs 
    {
        public IMediator Mediator
        {
            get;
            set;
        }
    }

    public interface IMediator : IMathObjectStack 
    {
        event EventHandler<MediatorArgs> CurrentNumberChaned;

        event EventHandler<MediatorArgs> NumberStackChaned;

        Stack<IMathObject> Numbers { get; }

        string CurrentNumber { get; set; }

        void InsertNumber(object digit);

        void Enter();

        void Clear();
    }
}

