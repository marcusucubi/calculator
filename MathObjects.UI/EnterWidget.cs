using System;
using MathObjects.UI.Stack;
using MathObjects.UI.Mediator;

namespace MathObjects.UI
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class EnterWidget : Gtk.Bin
    {
        IMediator mediator;

        InputWidget input;

        public EnterWidget()
        {
            this.Build();

            this.button2.CanFocus = false;

            this.button2.Clicked += (sender, e) =>
                {
                    if (this.input.CalcDisplay.Length > 0)
                    {
                        if (this.mediator.Enter(this.input.CalcDisplay))
                        {
                            this.input.CalcDisplay = "";
                        }
                    }
                };
        }

        public void Connect(
            IMediator mediator,
            InputWidget input)
        {
            this.mediator = mediator;
            this.input = input;
        }
    }
}

