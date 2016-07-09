using System;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class HasChildrenEx
    {
        public static Ref FindRef(this IHasChildren hasChildren, string name)
        {
            var test = hasChildren as Ref;
            if (test != null)
            {
                if (test.Name == name)
                {
                    return test;
                }
            }

            foreach (var child in hasChildren.Children)
            {
                var refTest = child as Ref;
                if (refTest != null)
                {
                    if (refTest.Name == name)
                    {
                        return refTest;
                    }
                }

                var test2 = child as IHasChildren;
                if (test2 != null)
                {
                    return test2.FindRef(name);
                }
            }

            return null;
        }
    }
}

