using System;

namespace MathObjects.Core.Extension
{
    public interface IExtensionableObject
    {
        ExtensionCollection ExtensionCollection
        {
            get;
        }
    }
}

