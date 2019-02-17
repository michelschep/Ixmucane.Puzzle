namespace Ixmucane.Puzzle {
    public class Size {
        private readonly int _width;
        private readonly int _height;

        public Size(int width, int height) {
            _width = width;
            _height = height;
        }

        public int Width {
            get { return _width; }
        }

        public int Height {
            get { return _height; }
        }

        public override string ToString() {
            return string.Format("({0},{1})", Width, Height);
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            var size = obj as Size;

            if (size == null)
                return false;

            return Width == size.Width && Height == size.Height;
        }

        public override int GetHashCode() {
            unchecked {
                var result = 0;
                result = (result * 397) ^ this.Width;
                result = (result * 397) ^ this.Height;
                return result;
            }
        }
    }
}