using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class MathObjectEx
    {
        public static double GetDouble(this IMathObject obj)
        {
            var hasOutput = obj as IHasOutput;
            if (hasOutput is ErrorObject || hasOutput == null)
            {
                return float.NaN;
            }

            if (hasOutput != null)
            {
                var output = hasOutput.Output;
                if (output is double)
                {
                    return (double)output;
                }

                if (output is ErrorObject)
                {
                    return float.NaN;
                }

                var has2 = hasOutput.Output as IHasOutput;
                if (has2 != null)
                {
                    if (has2.Output is double)
                    {
                        return (double)has2.Output;
                    }

                    return GetDouble((IMathObject)has2.Output);
                }
            }

            throw new Exception();
        }
    }
}

