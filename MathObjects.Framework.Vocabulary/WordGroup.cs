using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathObjects.Framework.Vocabulary
{
    public class WordGroup
    {
        readonly List<Word> words;

        readonly string name;

        public WordGroup(string name, string[] words)
        {
            this.name = name;
            this.words = Word.Create(words).ToList();
        }

        public string Name
        {
            get { return this.name; }
        }

        public ReadOnlyCollection<Word> Words
        {
            get { return this.words.AsReadOnly(); }
        }
    }
}

