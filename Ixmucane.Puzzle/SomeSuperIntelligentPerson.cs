using System;
using System.Collections.Generic;

namespace Ixmucane.Puzzle {
    public class SomeSuperIntelligentPerson {
        //private IList<string> _map = new List<string>();
        private readonly HashSet<string> _map = new HashSet<string>();
        private readonly Queue<BoardHistory> _queue = new Queue<BoardHistory>();
        private Piece _targetPiece;

        public BoardHistory SolvePuzzle(Board board) {
            var pieces = board.Pieces;
            _targetPiece = ResolveTargetPiece(pieces);

            _map.Add(board.Identifier());

            var boardHistory = new BoardHistory(board, new List<BoardMove>(), false);
            _queue.Enqueue(boardHistory);

            while (_queue.Count > 0) {
                var item = _queue.Dequeue();
                var newBoardHistory = ApplyAllMoves(item);

                if (newBoardHistory != null) {
                    if (newBoardHistory.IsSolved) {
                        Console.WriteLine(DateTimeOffset.UtcNow);
                        Console.WriteLine("Number of boards analyzed: {0}", _map.Count);
                        Console.WriteLine("Press the ANY key");
                        Console.ReadLine();
                        return newBoardHistory;
                    }
                }
            }
           
            throw new DramaticalFailure("No solution!!");
        }

        private BoardHistory ApplyAllMoves(BoardHistory boardHistory) {
            var list = boardHistory.Board.GetMovesBoard();

            foreach (var puzzleMove in list) {
                var newBoardHistory = DoMove(boardHistory, puzzleMove);
                if (newBoardHistory.IsSolved)
                    return newBoardHistory;
            }

            return boardHistory;
        }

        private BoardHistory DoMove(BoardHistory boardHistory, BoardMove boardMove) {
            var newBoard = boardHistory.Board.Copy();
            newBoard.MovePiece(boardMove.Piece, boardMove.MoveType);

            var identifier = newBoard.Identifier();
            if (_map.Contains(identifier))
                return boardHistory;

            _map.Add(identifier);

            var newMoveList = new List<BoardMove>();
            newMoveList.AddRange(boardHistory.Moves);
            newMoveList.Add(boardMove);

            var positionForTargetPiece = newBoard.GetPointOf(_targetPiece);
            var isSolved = Equals(positionForTargetPiece, Point.For(1, 0));

            var newBoardHistory = new BoardHistory(newBoard, newMoveList, isSolved);
            _queue.Enqueue(newBoardHistory);

            return newBoardHistory;
        }

        private Piece ResolveTargetPiece(IEnumerable<Piece> pieces) {
            foreach (var piece in pieces) {
                if (piece.Size.Equals(new Size(2, 2)))
                    return piece;
            }
            throw new ArgumentException("Target piece not found");
        }
    }

    public class DramaticalFailure : Exception {
        public DramaticalFailure(string noSolution) {
        }
    }
}