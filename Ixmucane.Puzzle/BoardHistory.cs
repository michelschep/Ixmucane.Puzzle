using System.Collections.Generic;

namespace Ixmucane.Puzzle {
    public class BoardHistory {
        private readonly Board _board;
        private readonly IList<BoardMove> _moves;
        private readonly bool _isSolved;

        public BoardHistory(Board board, IList<BoardMove> moves, bool isSolved) {
            _isSolved = isSolved;
            _board = board;
            _moves = moves;
        }

        public Board Board {
            get { return _board; }
        }

        public IList<BoardMove> Moves {
            get { return _moves; }
        }

        public bool IsSolved {
            get { return _isSolved; }
        }
    }
}