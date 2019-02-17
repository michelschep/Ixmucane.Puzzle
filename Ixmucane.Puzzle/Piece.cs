namespace Ixmucane.Puzzle {
    public class Piece {
        private readonly Size _size;
        private string _string;

        public Piece(Size size) {
            _size = size;
            _string = string.Format("{0}", Size);
        }

        public Size Size {
            get { return _size; }
        }

        public override string ToString() {
            return _string;
        }
    }
}
