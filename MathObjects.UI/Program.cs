using System;
using Gtk;
using MathObjects.Framework;
using MathObjects.Core.Plugin;
using MathObjects.Framework.Registry;

namespace MathObjects.UI
{
    class MainClass
    {
        public static PluginRegistry PluginRegistry
        {
            get;
            protected set;
        }

        public static void Main (string[] args)
        {
            Application.Init();

            MainClass.PluginRegistry = new PluginRegistry();

            MainClass.PluginRegistry.Load("MathObjects.Plugin.Rational.dll");
            MainClass.PluginRegistry.Load("MathObjects.Plugin.Integers.dll");
            MainClass.PluginRegistry.Load("MathObjects.Plugin.Symmetric.dll");

            var win = new MainWindow2();
            win.Show();
            Application.Run();
        }
    }
}
