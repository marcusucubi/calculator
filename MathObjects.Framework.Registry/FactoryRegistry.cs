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

        public static readonly string MULTIPLY = "multiply";

        public static readonly string INVERSE = "inverse";

        readonly Dictionary<string, IMathObjectFactory> objectMap = 
            new Dictionary<string, IMathObjectFactory>();

        readonly Dictionary<string, IMathOperationFactory> operationMap = 
            new Dictionary<string, IMathOperationFactory>();

        readonly Dictionary<string, IMathOperationFactory2> operationMap2 = 
            new Dictionary<string, IMathOperationFactory2>();
        
        public ReadOnlyDictionary<string, IMathObjectFactory> ObjectDictionary
        {
            get { return new ReadOnlyDictionary<string, IMathObjectFactory>(this.objectMap); }
        }

        public ReadOnlyDictionary<string, IMathOperationFactory> BinaryOperationDictionary
        {
            get { return new ReadOnlyDictionary<string, IMathOperationFactory>(this.operationMap); }
        }

        public ReadOnlyDictionary<string, IMathOperationFactory2> OperationDictionary
        {
            get { return new ReadOnlyDictionary<string, IMathOperationFactory2>(this.operationMap2); }
        }

        public void RegisterOperationFactory(string name, IMathOperationFactory factory)
        {
            this.operationMap[name] = factory;
        }

        public void RegisterOperationFactory2(string name, IMathOperationFactory2 factory)
        {
            this.operationMap2[name] = factory;
        }

        public void RegisterObjectFactory(string name, IMathObjectFactory factory)
        {
            this.objectMap[name] = factory;
        }

        public IMathOperationFactory GetOperationFactory(string name)
        {
            return this.operationMap[name];
        }

        public IMathOperationFactory2 GetOperationFactory2(string name)
        {
            return this.operationMap2[name];
        }

        public IMathObjectFactory GetObjectFactory(string name)
        {
            return this.objectMap[name];
        }
    }
}

