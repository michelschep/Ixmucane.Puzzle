namespace Ixmucane.Puzzle {
    public class BoardMove {
        private readonly Piece _piece;
        private readonly Point _point;
        private readonly MoveType _moveType;

        public BoardMove(Piece piece, Point point, MoveType moveType) {
            _piece = piece;
            _point = point;
            _moveType = moveType;
        }

        public Piece Piece {
            get {
                return _piece;
            }
        }

        public MoveType MoveType {
            get {
                return _moveType;
            }
        }

        public Point Point {
            get { return _point; }
        }

        public override string ToString() {
            return string.Format("Move piece {0} on {1} ==> {2}", Piece, Point, MoveType);
        }
    }
}