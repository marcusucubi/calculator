using System;
using System.Collections.Generic;

namespace MathObjects.Core.Plugin
{
    public interface IPluginLoader
    {
        IList<IPlugin> Plugins { get; }

        void Load(string name);

        Type GetType(string Name);

        Type[] GetTypes();
    }
}
