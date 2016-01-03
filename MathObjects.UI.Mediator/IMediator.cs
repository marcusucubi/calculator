using System;
using MathObjects.Framework;
using System.Collections.Generic;

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

    public interface IMediator
    {
        event EventHandler<MediatorArgs> CurrentNumberChaned;

        event EventHandler<MediatorArgs> NumberStackChaned;

        Stack<IMathObject> Numbers { get; }

        string CurrentNumber { get; set; }

        void InsertNumber(object digit);

        void Perform(IBinaryOperation op);

        void Perform(IMathOperation op);

        void Enter();

        void Clear();

        void Pop();
    }
}

