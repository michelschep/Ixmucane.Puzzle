using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ixmucane.Puzzle {
    public class Board {
        private readonly Dictionary<Piece, Point> _board = new Dictionary<Piece, Point>();
        private readonly Region _boardRegion;

        public Board(Size size) {
            _boardRegion = new Region(new Point(0, 0), size);
        }

        public Board Copy() {
            var newBoard = new Board(BoardRegion.Size);
            foreach (var piece in Pieces) {
                newBoard.AddPiece(piece, _board[piece]);
            }
            return newBoard;
        }

        public IList<Piece> Pieces {
            get { return _board.Keys.ToList(); }
        }

        public Region BoardRegion {
            get { return _boardRegion; }
        }

        public void AddPiece(Piece newPiece, Point point) {
            var targetRegionPiece = new Region(point, newPiece.Size);

            if (!BoardRegion.Contains(targetRegionPiece))
                throw new ArgumentOutOfRangeException("point", point, string.Format("Point [{0}] not in Region [{1}]", point, BoardRegion));

            foreach (var p in _board.Keys) {
                var regionPiece = new Region(_board[p], p.Size);

                if (regionPiece.ContainsSome(targetRegionPiece))
                    throw new ArgumentOutOfRangeException("point", point, string.Format("Region newPiece [{0}] already occipied", newPiece));
            }

            _board.Add(newPiece, point);
        }

        public IEnumerable<MoveType> GetMovesFor(Piece piece) {
            return GetMovesPiece(piece, _board[piece]).Select(m => m.MoveType);
        }

        public IList<BoardMove> GetMovesBoard() {
            var moves = new List<BoardMove>();
            foreach (var piece in _board.Keys) {
                moves.AddRange(GetMovesPiece(piece, _board[piece]));
            }
            return moves;
        }

        private IEnumerable<BoardMove> GetMovesPiece(Piece piece, Point point) {
            var list = new List<BoardMove>();

            if (CanPieceShift(piece, point, new Vector(-1, 0)))
                list.Add(new BoardMove(piece, point, MoveType.Left));

            if (CanPieceShift(piece, point, new Vector(1, 0)))
                list.Add(new BoardMove(piece, point, MoveType.Right));

            if (CanPieceShift(piece, point, new Vector(0, -1)))
                list.Add(new BoardMove(piece, point, MoveType.Down));

            if (CanPieceShift(piece, point, new Vector(0, 1)))
                list.Add(new BoardMove(piece, point, MoveType.Up));

            return list;
        }

        private bool CanPieceShift(Piece piece, Point point, Vector vector) {
            var newPoint = point.Shift(vector);
            var oldRegion = new Region(point, piece.Size);
            var newRegion = new Region(newPoint, piece.Size);
            var diffRegionInPoints = newRegion - oldRegion;

            if (!BoardRegion.Contains(diffRegionInPoints))
                return false;

            if (IsRegionOccupied(diffRegionInPoints))
                return false;

            return true;
        }

        private bool IsRegionOccupied(IEnumerable<Point> points) {
            foreach (var piece in _board.Keys) {
                var regionPiece = new Region(_board[piece], piece.Size);

                if (regionPiece.ContainsSome(points))
                    return true;
            }
            return false;
        }

        public void MovePiece(Piece piece, MoveType moveType) {
            if (piece == null)
                throw new ArgumentNullException("piece");

            var point = _board[piece];
            if (point == null)
                throw new ArgumentException(string.Format("Piece {0} is not on board", piece));

            if (!GetMovesFor(piece).Contains(moveType))
                throw new ArgumentException(string.Format("Invalid move with piece {0}", piece));

            var vector = GetVector(moveType);

            _board[piece] = point.Shift(vector);
        }

        private Vector GetVector(MoveType moveType) {
            switch (moveType) {
                case MoveType.Down:
                    return new Vector(0, -1);
                case MoveType.Up:
                    return new Vector(0, 1);
                case MoveType.Right:
                    return new Vector(1, 0);
                case MoveType.Left:
                    return new Vector(-1, 0);
            }
            throw new InvalidEnumArgumentException("Unknown moveType");
        }

        public Point GetPointOf(Piece piece) {
            return _board[piece];
        }

        public string Identifier() {
            var stringBuilder = new StringBuilder();

            var map = new Dictionary<Size, IList<Point>>();
            foreach (var piece in Pieces) {
                if (map.ContainsKey(piece.Size))
                    map[piece.Size].Add(GetPointOf(piece));
                else {
                    map.Add(piece.Size, new List<Point> {GetPointOf(piece)});
                }
            }

            foreach (var item in map) {
                stringBuilder.AppendFormat("[{0}]", item.Key);
                var result = item.Value.OrderBy(p => p.X).ThenBy(p=>p.Y);
                foreach (var point in result) {
                    stringBuilder.AppendFormat("{0}", point);
                }
            }
            return stringBuilder.ToString();
        }

        public Piece GetPiece(Point point) {
            foreach (var piece in Pieces) {
                var region = new Region(_board[piece], piece.Size);
                if (region.Contains(point))
                    return piece;
            }
            return null;
        }
    }
}
