using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class MathObjectEx
    {
        public static double GetDouble(this IMathObject obj)
        {
            var hasTuple = obj as IHasDouble;
            if (hasTuple != null)
            {
                return hasTuple.Double;
            }

            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var has2 = hasOutput.Output as IHasDouble;
                return has2.Double;
            }

            throw new Exception();
        }
    }
}

