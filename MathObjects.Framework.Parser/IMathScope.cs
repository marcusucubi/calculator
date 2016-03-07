using System;

namespace MathObjects.Framework.Parser
{
    public interface IMathScope
    {
        IMathObject Get(string name);

        void Put(string namem, IMathObject obj);
    }
}

