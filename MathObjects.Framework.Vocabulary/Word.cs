using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Framework.Vocabulary
{
    public class Word
    {
        readonly string data;

        public static Word[] Create(string[] strings)
        {
            var result = new List<Word>();

            foreach(var s in strings)
            {
                result.Add(new Word(s));
            }

            return result.ToArray();
        }

        public Word(string data)
        {
            this.data = data;
        }

        public string Data
        {
            get { return this.data; }
        }
    }
}

