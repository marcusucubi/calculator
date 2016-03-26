using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class MathObjectEx
    {
        public static double GetDouble(this IMathObject obj)
        {
            return obj.GetValue<double>();
            /*
            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var hasValue = hasOutput.Output as IHasValue;
                if (hasValue != null)
                {
                    return ((MathValue)hasValue.Value).DoubleValue;
                }
            }
            else
            {
                var hasValue = obj as IHasValue;
                if (hasValue != null)
                {
                    return ((MathValue)hasValue.Value).DoubleValue;
                }
            }

            return double.NaN;
            */
        }
    }
}

