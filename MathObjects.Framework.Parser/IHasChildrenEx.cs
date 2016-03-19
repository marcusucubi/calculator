using System;
using System.Collections.Generic;
using System.Linq;

namespace MathObjects.Framework.Parser
{
    public static class HasChildrenEx
    {
        public static void ForEach(
            this IHasChildren hasChildren, 
            Action<IMathObject> action)
        {
            foreach (var child in hasChildren.Children)
            {
                action.Invoke(child);

                var test = child as IHasChildren;
                if (test != null)
                {
                    test.ForEach(action);
                }
            }
        }
    }
}

