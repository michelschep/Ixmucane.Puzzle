namespace Ixmucane.Puzzle {
    public class Coordinates {
        private readonly int _x;
        private readonly int _y;

        public Coordinates(int x, int y) {
            _x = x;
            _y = y;
        }

        public int X {
            get { return _x; }
        }

        public int Y {
            get { return _y; }
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            var position = obj as Coordinates;

            if (position == null)
                return false;

            return this.X == position.X && this.Y == position.Y;
        }

        public override string ToString() {
            return string.Format("({0},{1})", X, Y);
        }

        public Point Shift(Vector vector) {
            return new Point(X + vector.X, Y + vector.Y);
        }
    }
}