using System;
using MathObjects.UI.Mediator;

namespace MathObjects.UI.Stack
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class StackButtonWidget : Gtk.Bin
    {
        public StackButtonWidget()
        {
            this.Build();
        }

        public IMediator Mediator
        {
            get;
            set;
        }

        public InputWidget InputWidget
        {
            get;
            set;
        }

        protected void OnButtonPopClicked (object sender, EventArgs e)
        {
            this.Mediator.Pop();
        }

        protected void OnButtonClearClicked (object sender, EventArgs e)
        {
            this.Mediator.Clear();
        }

        protected void OnButtonPushClicked (object sender, EventArgs e)
        {
            this.Mediator.Enter(InputWidget.CalcDisplay);
            this.InputWidget.CalcDisplay = "";
        }
    }
}

