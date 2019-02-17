using System;
using NUnit.Framework;

namespace Ixmucane.Puzzle.Test {
    [TestFixture]
    public class CreateBoardTest {
        [Test]
        public void When_piece_is_put_on_position_then_it_is_on_this_position() {
            var board = new Board(new Size(1,1));
            var piece = new Piece(new Size(1,1));
            var point = new Point(0, 0);

            board.AddPiece(piece, point);
            
            var positionPiece = board.GetPointOf(piece);

            Assert.That(positionPiece, Is.EqualTo(point), "Point");
        }

        [Test]
        public void When_piece_is_put_completely_outside_board_region_then_throws() {
            var board = new Board(new Size(1, 1));
            var piece = new Piece(new Size(1, 1));
            var point = new Point(1, 0);

            var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => board.AddPiece(piece, point));
        }

        [Test]
        public void When_piece_is_put_partially_outside_board_region_then_throws() {
            var board = new Board(new Size(1, 1));
            var piece = new Piece(new Size(2, 1));
            var point = new Point(0, 0);

            var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => board.AddPiece(piece, point));
        }

        [Test]
        public void When_piece_is_put_on_position_already_occupied_then_throws() {
            var board = new Board(new Size(1,1));
            var firstPiece = new Piece(new Size(1,1));
            board.AddPiece(firstPiece, Point.For(0, 0));

            var secondPiece = new Piece(new Size(1,1));

            var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => board.AddPiece(secondPiece, Point.For(0, 0)));
        }

        [Test]
        public void When_piece_is_put_on_position_already_occupied2_then_throws() {
            var board = new Board(new Size(2,2));
            var firstPiece = new Piece(new Size(1,1));
            board.AddPiece(firstPiece, Point.For(1,0));

            var secondPiece = new Piece(new Size(2,1));
            var secondPosition = Point.For(0, 0);

            var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => board.AddPiece(secondPiece, secondPosition));
        }
    }
}
