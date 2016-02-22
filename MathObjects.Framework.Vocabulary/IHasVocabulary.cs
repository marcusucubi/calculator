using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace MathObjects.Framework.Vocabulary
{
    public interface IHasVocabulary
    {
        ReadOnlyCollection<WordGroup> WordGroups
        {
            get;
        }
    }
}

