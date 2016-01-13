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

            ErrorHandler.ExceptionEvent += (sender, e) =>
            { 
                this.label1.LabelProp = e.Exception.Message;
            };
        }
    }
}

