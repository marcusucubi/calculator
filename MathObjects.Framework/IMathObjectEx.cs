using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Core.Extension;

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

                DecorationManager.CopyDecorations(result, canCopy as IExtensionableObject);
            }

            return result;
        }

        public static bool IsDefined(this IMathObject obj)
        {
            var defined = obj as ICanBeDefined;
            if (defined != null)
            {
                return defined.IsDefinded;
            }

            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var output = hasOutput.Output;

                var defined2 = output as ICanBeDefined;
                if (defined2 != null)
                {
                    return defined2.IsDefinded;
                }
            }

            return true;
        }

        public static T GetValue<T>(this IMathObject obj)
        {
            var hasValue = obj as IHasValue;
            if (hasValue != null && typeof(T).IsAssignableFrom(hasValue.GetType()) )
            {
                return (T)hasValue;
            }

            var hasValue2 = obj as IHasValue;
            if (hasValue2 != null && hasValue2.Value != null &&
                typeof(T).IsAssignableFrom(hasValue2.Value.Value.GetType()) )
            {
                return (T)hasValue2.Value.Value;
            }

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

            var hasValue = output as IHasValue;
            if (hasValue != null && typeof(T).IsAssignableFrom(hasValue.GetType()) )
            {
                return (T)hasValue;
            }

            var hasValue2 = output as IHasValue;
            if (hasValue2 != null && hasValue2.Value != null &&
                typeof(T).IsAssignableFrom(hasValue2.Value.Value.GetType()) )
            {
                return (T)hasValue2.Value.Value;
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

