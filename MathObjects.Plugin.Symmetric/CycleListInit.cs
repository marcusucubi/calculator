using System;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public class CycleListInit
    {
        readonly List<int> cycleList;

        readonly List<Move> moves;

        List<int> permutedList;

        public CycleListInit()
        {
            cycleList = new List<int>();
            permutedList = new List<int>();
            moves = new List<Move>();
        }

        public CycleListInit(CycleListInit copy)
        {
            cycleList = new List<int>(copy.CycleSet);
            permutedList = new List<int>(copy.PermutedList);
            moves = new List<Move>(copy.Moves);
        }

        public List<int> CycleSet
        {
            get { return this.cycleList; }
        }

        public List<int> PermutedList
        {
            get { return this.permutedList; }
            set { this.permutedList = value; }
        }

        public List<Move> Moves
        {
            get { return this.moves; }
        }
    }
}

