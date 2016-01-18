using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public static class MathObjectEx
    {
        public static int GetInteger(this IMathObject obj)
        {
            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var output = hasOutput.Output;
                if (output is int)
                {
                    return (int)output;
                }

                var has2 = hasOutput.Output as IHasOutput;
                return (int)has2.Output;
            }

            throw new Exception();
        }
    }
}

