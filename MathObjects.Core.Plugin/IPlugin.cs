using System;

namespace MathObjects.Core.Plugin
{
    public interface IPlugin
    {
        void Startup(IPluginLoader loader);
    }
}
