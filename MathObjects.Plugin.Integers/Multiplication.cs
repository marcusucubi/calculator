using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Multiplication : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = GetValue(left);
            var rightValue = GetValue(right);

            return new MathObject(((int)leftValue * (int)rightValue) );
        }

        int GetValue(IMathObject obj)
        {
            var hasValue = obj as IHasValue;
            if (hasValue != null)
            {
                return hasValue.Value;
            }

            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var has2 = hasOutput.Output as IHasValue;
                return has2.Value;
            }

            throw new Exception();
        }

        public class Factory : IMathBinaryOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Multiply"; }
            }

            public IMathBinaryOperation Create(object parm)
            {
                return new Multiplication();
            }
        }
    }
}

