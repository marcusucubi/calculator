using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using MathObjects.Core.Plugin;

namespace MathObjects.Framework.Registry
{
    public class PluginRegistry
    {
        readonly Dictionary<string, IPlugin> names;

        public PluginRegistry()
        {
            names = new Dictionary<string, IPlugin>();
        }

        public ReadOnlyDictionary<string, IPlugin> Names
        {
            get { return new ReadOnlyDictionary<string, IPlugin>(this.names); }
        }

        public void Load(string path)
        {
            var loader = new PluginLoader();

            loader.Load(path);

            foreach (var plugin in loader.Plugins)
            {
                var name = path;

                var hasName = plugin as IHasName;
                if (hasName != null)
                {
                    name = hasName.Name;
                }

                this.names.Add(name, plugin);
            }
        }
    }
}

