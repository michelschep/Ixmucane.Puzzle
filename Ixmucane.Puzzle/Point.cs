namespace Ixmucane.Puzzle {
    public class Point : Coordinates {
        public Point(int x, int y)
            : base(x, y) {
        }

        public static Point For(int x, int y) {
            return new Point(x, y);
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            var position = obj as Coordinates;

            if (position == null)
                return false;

            return X == position.X && Y == position.Y;
        }

        public override int GetHashCode() {
            unchecked {
                var result = 0;
                result = (result * 397) ^ X;
                result = (result * 397) ^ Y;
                return result;
            }
        }
    }
}