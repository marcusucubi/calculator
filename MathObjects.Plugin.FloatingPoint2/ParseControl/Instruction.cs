using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint2
{
    public class Instruction : AbstractMathOperation
    {
        readonly string name;

        readonly int size;

        public override string Symbol { get { return name; } }

        public override int NumberOfParameters { get { return size; } }

        public string Name { get { return name; } }

        public Instruction(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public override IMathObject Perform(IMathObject[] objs)
        {
            return new Data(objs, name);
        }
    }
}

