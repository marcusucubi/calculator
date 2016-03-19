using System;

namespace MathObjects.Framework
{
    public static class IMathObjectEx
    {
        public static IMathObject CopyByValue(this IMathObject obj)
        {
            var result = obj;

            var canCopy = obj as ICanCopyByValue;

            if (canCopy != null)
            {
                result = canCopy.CopyByValue();
            }

            return result;
        }

        public static T GetValue<T>(this IMathObject obj)
        {
            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                return hasOutput.GetValue<T>();
            }

            return default(T);
        }

        public static T GetValue<T>(this IHasOutput obj)
        {
            var output = obj.Output;
            if (output is T)
            {
                return (T)output;
            }

            var mobj = output as IMathObject;
            if (mobj != null)
            {
                return mobj.GetValue<T>();
            }

            var hasOutput = output as IHasOutput;
            if (hasOutput != null)
            {
                return hasOutput.GetValue<T>();
            }

            return default(T);
        }
    }
}

