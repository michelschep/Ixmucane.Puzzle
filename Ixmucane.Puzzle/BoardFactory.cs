namespace Ixmucane.Puzzle {
    public class BoardFactory {
        public static Board CreateRedDonkeyPuzzle() {
            var board = new Board(new Size(4, 5));

            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 3));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(3, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(3, 3));

            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 0));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 1));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(2, 0));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(2, 1));

            board.AddPiece(new Piece(new Size(2, 1)), Point.For(1, 2));

            board.AddPiece(new Piece(new Size(2, 2)), Point.For(1, 3));

            return board;
        }

        public static Board CreateSimpleTrafficJamPuzzle() {
            var board = new Board(new Size(4, 5));

            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 3));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(3, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(3, 3));

            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 1));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 2));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(2, 1));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(2, 2));

            board.AddPiece(new Piece(new Size(2, 1)), Point.For(1, 0));

            board.AddPiece(new Piece(new Size(2, 2)), Point.For(1, 3));

            return board;
        }

        public static Board CreateCenturyBoard() {
            var board = new Board(new Size(4, 5));

            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 2));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(1, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(3, 2));

            board.AddPiece(new Piece(new Size(1, 1)), Point.For(0, 1));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(0, 4));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(3, 1));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(3, 4));

            board.AddPiece(new Piece(new Size(2, 1)), Point.For(0, 0));
            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 0));

            board.AddPiece(new Piece(new Size(2, 2)), Point.For(1, 3));

            return board;
        }

        public static Board CreateSuperCenturyBoard() {
            var board = new Board(new Size(4, 5));

            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 1));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 3));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(1, 2));

            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 4));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(2, 4));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(3, 4));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(3, 1));

            board.AddPiece(new Piece(new Size(2, 1)), Point.For(1, 1));
            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 0));

            board.AddPiece(new Piece(new Size(2, 2)), Point.For(2, 2));

            return board;
        }

        public static Board CreateDadsPuzzlerBoard() {
            var board = new Board(new Size(4, 5));

            board.AddPiece(new Piece(new Size(1, 2)), Point.For(0, 0));
            board.AddPiece(new Piece(new Size(1, 2)), Point.For(1, 0));

            board.AddPiece(new Piece(new Size(1, 1)), Point.For(0, 2));
            board.AddPiece(new Piece(new Size(1, 1)), Point.For(1, 2));

            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 0));
            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 1));
            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 3));
            board.AddPiece(new Piece(new Size(2, 1)), Point.For(2, 4));

            board.AddPiece(new Piece(new Size(2, 2)), Point.For(0, 3));

            return board;
        }
    }
}
