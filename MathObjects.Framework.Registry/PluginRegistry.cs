using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using MathObjects.Core.Plugin;

namespace MathObjects.Framework.Registry
{
    public class PluginRegistry
    {
        readonly Dictionary<IPlugin, FactoryRegistry> plugins;

        readonly Dictionary<string, IPlugin> names;

        public PluginRegistry()
        {
            plugins = new Dictionary<IPlugin, FactoryRegistry>();
            names = new Dictionary<string, IPlugin>();
        }

        public void Registry(IPlugin plugin, FactoryRegistry registry)
        {
            this.plugins.Add(plugin, registry);
        }

        public ReadOnlyDictionary<IPlugin, FactoryRegistry> Plugins
        {
            get { return new ReadOnlyDictionary<IPlugin, FactoryRegistry>(this.plugins); }
        }

        public ReadOnlyDictionary<string, IPlugin> Names
        {
            get { return new ReadOnlyDictionary<string, IPlugin>(this.names); }
        }

        public void Load(string path)
        {
            var loader = new PluginLoader();

            loader.Load(path);

            var registry = new FactoryRegistry();

            foreach (var plugin in loader.Plugins)
            {
                var hasInit = plugin as IHasInit;

                if (hasInit != null)
                {
                    hasInit.Init(registry);

                    this.plugins.Add(plugin, registry);
                    this.names.Add(path, plugin);
                }
            }
        }
    }
}

