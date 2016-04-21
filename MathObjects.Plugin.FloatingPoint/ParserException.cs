using System;
using System.Collections.Generic;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ParserException : Exception 
    {
        readonly List<MathObjects.Plugin.FoatingPoint.ErrorListener.Description> list;

        public List<MathObjects.Plugin.FoatingPoint.ErrorListener.Description> Descriptions
        {
            get { return this.list; }
        }

        public ParserException(List<MathObjects.Plugin.FoatingPoint.ErrorListener.Description> descriptions)
        {
            this.list = descriptions;
        }
    }
}

