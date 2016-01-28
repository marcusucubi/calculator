using System;

namespace MathObjects.Framework
{
    public static class IMathObjectEx
    {
        public static T GetValue<T>(this IMathObject obj)
        {
            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var output = hasOutput.Output;
                if (output is T)
                {
                    return (T)output;
                }

                var has2 = hasOutput.Output as IHasOutput;
                if (has2.Output is T)
                {
                    return (T)has2.Output;
                }

                return GetValue<T>((IMathObject)has2.Output);
            }

            throw new Exception();
        }
    }
}

