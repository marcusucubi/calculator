using System;
using System.ComponentModel;
using MathObjects.Framework.Registry;
using MathObjects.Core.Plugin;
using Gtk;

namespace MathObjects.UI
{
    public class MathPluginChangedArgs : EventArgs
    {
        readonly IPlugin plugin;

        public MathPluginChangedArgs(IPlugin plugin)
        {
            this.plugin = plugin;
        }

        public IPlugin Plugin
        {
            get { return this.plugin; }
        }
    }

    [ToolboxItem(true)]
    public partial class FieldWidget : Gtk.Bin
    {
        public event EventHandler<MathPluginChangedArgs> MathPluginChanged;

        PluginRegistry registry;

        public FieldWidget()
        {
            this.Build();

            this.combobox1.Changed += (sender, e) => 
                {
                    TreeIter iter;


                    if (combobox1.GetActiveIter(out iter))
                    {
                        var s = (string) combobox1.Model.GetValue (iter, 0);

                        var plugin = this.registry.Names[s];
                        var args = new MathPluginChangedArgs(plugin);

                        if (MathPluginChanged != null)
                        {
                            MathPluginChanged(plugin, args);
                        }
                    }
                };
        }

        public void Connect(PluginRegistry registry)
        {
            this.registry = registry;

            foreach (var plugin in registry.Names.Keys)
            {
                this.combobox1.AppendText(plugin);
            }
        }
    }
}

