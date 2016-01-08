using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public class Moves
    {
        readonly List<Move> moves;

        public Moves(List<Move> moves)
        {
            this.moves = moves;
        }

        public List<Move> List
        {
            get { return this.moves; }
        }

        public Move First
        {
            get
            {
                if (moves.Count == 0)
                {
                    return null;
                }

                return moves.OrderBy(x => x.From).First();
            }
        }

        public Move GetNext(Move move)
        {
            if (moves.Count == 0)
            {
                return null;
            }

            return moves.Find(x => x.From == move.To);
        }
    }
}

