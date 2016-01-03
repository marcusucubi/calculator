﻿using System;
using Gdk;
using MathObjects.UI.Mediator;

namespace MathObjects.UI.Input
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        IMediator mediator;

        public InputWidget()
        {
            this.Build();
        }

        public void Connect(IMediator mediator)
        {
            this.mediator = mediator;
            this.stackbuttonwidget1.Mediator = mediator;

            this.mediator.CurrentNumberChaned += (sender, e) => 
                { 
                    if (this.mediator.CurrentNumber == "")
                    {
                        this.entry1.Text = ""; 
                    }
                    else
                    {
                        this.entry1.Text = "" + this.mediator.CurrentNumber; 
                    }
                };
        }

        public string CalcDisplay
        {
            get { return this.entry1.Text ; }
        }
    }
}

