using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint2
{
    public class MathOperationFactory :
        AbstractMathObject, IMathOperationFactory2
    {
        readonly int numberOfParameters;

        readonly string symbol;

        readonly string name;

        public MathOperationFactory(
            int numberOfParameters, 
            string symbol, 
            string name)
        {
            this.numberOfParameters = numberOfParameters;
            this.symbol = symbol;
            this.name = name;
        }

        public int NumberOfParameters 
        { 
            get { return numberOfParameters; } 
        }

        public string Symbol { get { return symbol; } }

        public string Name { get { return name; } }

        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(
            IMathOperationFactoryContext context)
        {
            return new Instruction(this.name, 1);
        }
    }
}

