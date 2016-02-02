using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public interface ICanDecorate
    {
        IDictionary<Type, object> DecorationMap { get; }

        void CopyDecorations(ICanDecorate decorate);
    }
}

