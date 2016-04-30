using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace MathObjects.Framework.Parser
{
    public class MathObjectStack : IMathObjectStack
    {
        public event EventHandler<MathObjectStackArgs> StackChanged;

        readonly Stack<IMathObject> objectStack;

        public MathObjectStack()
        {
            objectStack = new Stack<IMathObject>();
        }

        public MathObjectStack(Stack<IMathObject> objectStack)
        {
            this.objectStack = objectStack;
        }

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

        public IMathObjectStack Clone()
        {
            return new MathObjectStack(new Stack<IMathObject>(this.objectStack)); 
        }

        public IMathObject Peek()
        {
            return this.objectStack.Peek();
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
                IMathObject obj;

                if (this.objectStack.Count > 0)
                {
                    obj = this.objectStack.Pop();
                }
                else
                {
                    obj = new UndefinedObject();
                }

                list.Add(obj);
            }

            return list.ToArray();
        }

        public IMathObject Push(IMathObject obj)
        {
            Debug.Assert(obj != null);

            if (obj is IMathOperation)
            {
                return Push((IMathOperation) obj);
            }

            objectStack.Push(obj);

            FireStackChanged();

            return obj;
        }

        public IMathObject Push(CompositeOperation composite)
        {
            Push(composite.First);

            var result = Push(composite.Second);

            FireStackChanged();

            return result;
        }

        public IMathObject Push(IMathOperation op)
        {
            if (op is CompositeOperation)
            {
                return Push((CompositeOperation) op);
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

            return result;
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

        public IMathObject[] ToArray()
        {
            return this.objectStack.ToArray().Reverse().ToArray();
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

