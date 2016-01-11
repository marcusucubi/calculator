using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MathObjects.Core.Plugin
{
    public delegate bool IsAttributeHandler(object obj);

    public class PluginLoader : IPluginLoader
    {
        readonly IList<IPlugin> plugins = new List<IPlugin>();

        readonly IDictionary<string, Assembly> assemblies = 
            new Dictionary<string, Assembly>();
        
        public IList<IPlugin> Plugins
        {
            get { return plugins; }
        }

        public virtual void Load(string name)
        {
            Load(name, IsModuleAttribute);
        }

        public Type GetType(string name)
        {
            Type result = null;

            foreach (var a in this.assemblies.Values)
            {
                Type[] types = a.GetTypes();
                foreach(var t in types)
                {
                    if (t.Name.ToLower() == name.ToLower())
                    {
                        result = t;
                        break;
                    }

                    if (t.FullName.ToLower() == name.ToLower())
                    {
                        result = t;
                        break;
                    }
                }

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        public Type[] GetTypes()
        {
            var result = new List<Type>();

            foreach (var a in this.assemblies.Values)
            {
                result.AddRange(a.GetTypes());
            }

            return result.ToArray();
        }

        public void Load(string name, IsAttributeHandler handler)
        {
            string fullPath = Path.GetFullPath(name);
            var a = Assembly.LoadFile(fullPath);

            assemblies[fullPath] = a;

            var array = a.GetTypes();
            foreach (var theType in array)
            {
                if (IsModule(theType, handler))
                {
                    var module = Activator.CreateInstance(
                        theType, false) as IPlugin;

                    module.Startup(this);

                    plugins.Add(module);
                }
            }
        }

        public static bool IsModuleAttribute(object obj)
        {
            return (obj is PluginAttribute);
        }

        bool IsModule(
            ICustomAttributeProvider t, 
            IsAttributeHandler handler)
        {
            bool result = false;
			
            var attributes = t.GetCustomAttributes(false);
            foreach (var attr in attributes)
            {
                if (handler(attr))
                {
                    result = true;
                    break;
                }
            }
			
            return result;
        }
    }
}
