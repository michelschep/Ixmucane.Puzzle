using NUnit.Framework;

namespace Ixmucane.Puzzle.Test {
    [TestFixture]
    public class PlayGameTest {
        [Test]
        public void When_no_moves_are_possible_then_return_empty_list() {
            var board = new Board(new Size(1, 1));

            var moves = board.GetMovesBoard();

            Assert.That(moves, Is.Empty, "Moves");
        }

        [Test]
        public void When_moves_are_possible_then_return_list_with_valid_moves() {
            var board = new Board(new Size(3, 3));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(1,1));

            var moves = board.GetMovesFor(piece);

            Assert.That(moves, Contains.Item(MoveType.Down), "Moves");
            Assert.That(moves, Contains.Item(MoveType.Up), "Moves");
            Assert.That(moves, Contains.Item(MoveType.Left), "Moves");
            Assert.That(moves, Contains.Item(MoveType.Right), "Moves");
        }

        [Test]
        public void When_only_left_move_is_possible_then_return_list_with_valid_moves() {
            var board = new Board(new Size(2, 1));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(1, 0));

            var moves = board.GetMovesFor(piece);

            Assert.That(moves, Contains.Item(MoveType.Left), "Moves");
        }

        [Test]
        public void When_only_right_move_is_possible_then_return_list_with_valid_moves() {
            var board = new Board(new Size(2, 1));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(0, 0));

            var moves = board.GetMovesFor(piece);

            Assert.That(moves, Contains.Item(MoveType.Right), "Moves");
        }

        [Test]
        public void When_only_up_move_is_possible_then_return_list_with_valid_moves() {
            var board = new Board(new Size(1, 2));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(0, 0));

            var moves = board.GetMovesFor(piece);

            Assert.That(moves, Contains.Item(MoveType.Up), "Moves");
        }

        [Test]
        public void When_only_down_move_is_possible_then_return_list_with_valid_moves() {
            var board = new Board(new Size(1, 2));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(0, 1));

            var moves = board.GetMovesFor(piece);

            Assert.That(moves, Contains.Item(MoveType.Down), "Moves");
        }

        [Test]
        public void When_a_piece_is_moved_to_the_right() {
            var board = new Board(new Size(2, 1));
            var piece = new Piece(new Size(1, 1));
            board.AddPiece(piece, Point.For(0, 0));

            board.MovePiece(piece, MoveType.Right);
            var point = board.GetPointOf(piece);

            Assert.That(point, Is.EqualTo(Point.For(1, 0)), "");
        }

        [Test]
        public void When_a_piece_is_moved_downwards() {
            var board = new Board(new Size(4, 5));
            var piece = new Piece(new Size(2, 2));
            board.AddPiece(piece, Point.For(1, 3));

            board.MovePiece(piece, MoveType.Down);
            var point = board.GetPointOf(piece);

            Assert.That(point, Is.EqualTo(Point.For(1, 2)), "");
        }
    }
}