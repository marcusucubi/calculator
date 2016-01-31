using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MathObjects.Framework.Registry
{
    public class FactoryRegistry
    {
        public static readonly string OBJECT = "object";

        public static readonly string ADD = "+";

        public static readonly string SUBTRACT = "-";

        public static readonly string MULTIPLY = "*";

        public static readonly string DIVIDE = "/";

        public static readonly string INVERSE = "inverse";

        readonly Dictionary<string, IMathObjectFactory> objectMap = 
            new Dictionary<string, IMathObjectFactory>();

        readonly Dictionary<string, IMathOperationFactory> operationMap = 
            new Dictionary<string, IMathOperationFactory>();

        readonly Dictionary<string, IMathObjectFactory> functionMap = 
            new Dictionary<string, IMathObjectFactory>();

        public ReadOnlyDictionary<string, IMathObjectFactory> ObjectDictionary
        {
            get 
            { 
                return new ReadOnlyDictionary<string, IMathObjectFactory>(this.objectMap); 
            }
        }

        public ReadOnlyDictionary<string, IMathObjectFactory> FunctionDictionary
        {
            get 
            { 
                return new ReadOnlyDictionary<string, IMathObjectFactory>(this.functionMap); 
            }
        }

        public ReadOnlyDictionary<string, IMathOperationFactory> OperationDictionary
        {
            get 
            { 
                return new ReadOnlyDictionary<string, IMathOperationFactory>(
                    this.operationMap); 
            }
        }

        public void RegisterOperationFactory2(
            string name, 
            IMathOperationFactory factory)
        {
            this.operationMap[name] = factory;
        }

        public void RegisterObjectFactory(
            string name, 
            IMathObjectFactory factory)
        {
            this.objectMap[name] = factory;
        }

        public void RegisterFunctionFactory(
            string name, 
            IMathObjectFactory factory)
        {
            this.functionMap[name] = factory;
        }

        public IMathOperationFactory GetOperationFactory(string name)
        {
            return this.operationMap[name];
        }

        public IMathObjectFactory GetObjectFactory(string name)
        {
            return this.objectMap[name];
        }

        public IMathObjectFactory GetFunctionFactory(string name)
        {
            if (!this.functionMap.ContainsKey(name))
            {
                return null;
            }

            return this.functionMap[name];
        }
    }
}

