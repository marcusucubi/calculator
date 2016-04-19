using System;
using MathObjects.Framework;

namespace MathObjects.UI
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class ErrorWidget : Gtk.Bin
    {
        public ErrorWidget()
        {
            this.Build();

            //ErrorHandler.ErrorEvent += (sender, e) =>
            //    { 
            //        this.label1.LabelProp = e.Message;
            //    };
            
            //ErrorHandler.ErrorReset += (sender, e) =>
            //    { 
            //        this.label1.LabelProp = "";
            //    };
        }
    }
}

