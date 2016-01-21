using System;

namespace MathObjects.Framework
{
    public class FactoryContext : IMathObjectFactoryContext 
    {
        ArrayObject array = new ArrayObject();

        public object InitObject
        { 
            get; 
            set;
        }

        public ArrayObject Parameters 
        { 
            get { return array; } 
            set { this.array = value; }
        }
    }
}

