using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MathObjects.Framework.Registry
{
    public class FactoryRegistry
    {
        public static readonly string OBJECT = "object";

        public static readonly string ADD = "add";

        public static readonly string SUBTRACT = "subtract";

        public static readonly string MULTIPLY = "multiply";

        public static readonly string DIVIDE = "divide";

        public static readonly string INVERSE = "inverse";

        readonly Dictionary<string, IMathObjectFactory> objectMap = 
            new Dictionary<string, IMathObjectFactory>();

        readonly Dictionary<string, IMathBinaryOperationFactory> binaryOperationMap = 
            new Dictionary<string, IMathBinaryOperationFactory>();

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

        public ReadOnlyDictionary<string, IMathBinaryOperationFactory> BinaryOperationDictionary
        {
            get 
            { 
                return new ReadOnlyDictionary<string, IMathBinaryOperationFactory>(
                    this.binaryOperationMap); 
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

        public void RegisterBinaryOperationFactory(
            string name, 
            IMathBinaryOperationFactory factory)
        {
            this.binaryOperationMap[name] = factory;
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

        public IMathBinaryOperationFactory GetBinaryOperationFactory(string name)
        {
            return this.binaryOperationMap[name];
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
            return this.functionMap[name];
        }
    }
}

