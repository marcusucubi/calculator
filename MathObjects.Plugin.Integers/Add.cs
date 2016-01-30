﻿using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Add : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetInteger();
            var rightValue = right.GetInteger();

            var op = new AddObject(leftValue, rightValue);

            return new MathObject((int)op.Output);
        }

        public class Factory : IMathBinaryOperationFactory, IHasName
        {
            public string Name
            {
                get { return "+"; }
            }

            public IMathBinaryOperation Create(object parm)
            {
                return new Add();
            }
        }
    }
}

