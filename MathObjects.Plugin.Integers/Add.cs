﻿using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Add : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = (left as IHasValue).Value;
            var rightValue = (right as IHasValue).Value;

            return new MathObject((int)leftValue + (int)rightValue);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Add"; }
            }

            public IBinaryOperation Create(object parm)
            {
                return new Add();
            }
        }
    }
}

