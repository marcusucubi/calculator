using System;
using Gtk;
using MathObjects.Framework;
using MathObjects.Core.Plugin;
using MathObjects.Framework.Registry;

namespace MathObjects.UI
{
    class MainClass
    {
        //public static FactoryRegistry FactoryRegistry
        //{
        //    get;
        //    protected set;
        //}

        public static PluginRegistry PluginRegistry
        {
            get;
            protected set;
        }

        public static void Main (string[] args)
        {
            Application.Init ();

            //MainClass.FactoryRegistry = Load();
            MainClass.PluginRegistry = new PluginRegistry();

            MainClass.PluginRegistry.Load("MathObjects.Plugin.Rational.dll");
            MainClass.PluginRegistry.Load("MathObjects.Plugin.Integers.dll");

            MainWindow win = new MainWindow ();
            win.Show ();
            Application.Run ();
        }

        static FactoryRegistry Load()
        {
            var loader = new PluginLoader();

            loader.Load("MathObjects.Plugin.Rational.dll");
            //loader.Load("MathObjects.Plugin.Integers.dll");

            var registry = new FactoryRegistry();

            foreach (var plugin in loader.Plugins)
            {
                var hasInit = plugin as IHasInit;

                if (hasInit != null)
                {
                    hasInit.Init(registry);
                }
            }

            return registry;
        }
    }
}
