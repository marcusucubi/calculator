﻿using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Negative : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "-"; } }

        public string Name { get { return "-"; } }

        public override IMathObject Perform(IMathObject[] left)
        {
            var leftValue = left[0].GetDouble();

            return new NegativeObject(leftValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Negative();
            }
        }
    }
}

