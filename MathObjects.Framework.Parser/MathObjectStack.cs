using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser
{
    public class MathObjectStack : IMathObjectStack
    {
        public event EventHandler<MathObjectStackArgs> StackChanged;

        readonly Stack<IMathObject> objectStack = new Stack<IMathObject>();

        public int Size
        {
            get { return objectStack.Count; }
        }

        public IMathObject Top
        {
            get 
            { 
                if (this.objectStack.Count == 0)
                {
                    return new ErrorObject();
                }

                return this.objectStack.Peek(); 
            }
        }

        public Stack<IMathObject> ObjectStack
        {
            get { return this.objectStack; }
        }

        public IMathObject[] Peek(int size)
        {
            var list = new List<IMathObject>();

            for (int i = 0; i < size; i++)
            {
                list.Add(this.objectStack.ToArray()[i]);
            }

            return list.ToArray();
        }

        public IMathObject[] Pop(int size)
        {
            var list = new List<IMathObject>();

            for (int i = 0; i < size; i++)
            {
                list.Add(this.objectStack.Pop());
            }

            return list.ToArray();
        }

        public void Push(IMathObject obj)
        {
            if (obj is IMathOperation)
            {
                Push((IMathOperation) obj);
                return;
            }

            objectStack.Push(obj);

            FireStackChanged();
            ErrorHandler.ResetError(this);
        }

        public void Push(IMathOperation op)
        {
            if (this.objectStack.Count < op.NumberOfParameters)
            {
                return;
            }

            IMathObject result = null;
            if (op.NumberOfParameters >= 1)
            {
                result = new OperationWrapper(
                    Pop(op.NumberOfParameters), op);
            }
            else
            {
                result = op.Perform(null);
            }

            objectStack.Push(result);

            FireStackChanged();
        }

        public void Clear()
        {
            this.objectStack.Clear();

            FireStackChanged();
        }

        public IMathObject Pop()
        {
            IMathObject result = null;

            if (this.objectStack.Count > 0)
            {
                result = this.objectStack.Pop();

                FireStackChanged();
            }

            return result;
        }

        void FireStackChanged()
        {
            if (StackChanged != null)
            {
                var args = new MathObjectStackArgs();
                args.Stack = this;
                StackChanged(this, args);
            }
        }
    }
}

