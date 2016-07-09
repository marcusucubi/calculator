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

            var reg = new PluginRegistry();
            MainClass.PluginRegistry = reg;

            reg.Load("MathObjects.Plugin.FloatingPoint2.dll");
            reg.Load("MathObjects.Plugin.FloatingPoint.dll");
            //reg.Load("MathObjects.Plugin.Rational.dll");
            //reg.Load("MathObjects.Plugin.Integers.dll");
            reg.Load("MathObjects.Plugin.Symmetric.dll");

            var win = new MainWindow2();
            win.Show();
            Application.Run();
        }
    }
}
