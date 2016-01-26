using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser
{
    public class MathObjectStack : IMathObjectStack
    {
        public event EventHandler<MathObjectStackArgs> StackChanged;

        readonly Stack<IMathObject> objectStack = new Stack<IMathObject>();

        public MathObjectStack()
        {
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

        public void Push(IMathObject obj)
        {
            if (obj is IMathOperation)
            {
                Push((IMathOperation) obj);
                return;
            }

            if (obj is IMathBinaryOperation)
            {
                Push((IMathBinaryOperation) obj);
                return;
            }

            objectStack.Push(obj);

            FireStackChanged();
            ErrorHandler.ResetError(this);
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

        public void Push(IMathBinaryOperation op)
        {
            if (this.objectStack.Count < 2)
            {
                return;
            }

            var wrapper = new BinaryOperationWrapper(
                this.objectStack.Pop(), 
                this.objectStack.Pop(), op);

            objectStack.Push(wrapper);

            FireStackChanged();
        }

        public void Push(IMathOperation op)
        {
            if (this.objectStack.Count < op.NumberOfParameters)
            {
                return;
            }

            IMathObject result = null;
            if (op.NumberOfParameters == 1)
            {
                result = new OperationWrapper(
                    this.objectStack.Pop(), op);
            }
            else
            {
                result = op.Perform(null);
            }

            objectStack.Push(result);

            FireStackChanged();
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

