using System.Collections.Generic;
using System.Linq;

namespace Ixmucane.Puzzle {
    public class Region {
        private readonly Point _point;
        private readonly Size _size;

        public Region(Point point, Size size) {
            _point = point;
            _size = size;
        }

        public Point Point {
            get {
                return _point;
            }
        }

        public Size Size {
            get {
                return _size;
            }
        }

        public bool Contains(Region region) {
            var regionPoints = region.Points;
            return Contains(regionPoints);

        }

        public bool Contains(IEnumerable<Point> points) {
            return points.All(Contains);
        }

        public bool ContainsSome(IEnumerable<Point> points) {
            return points.Any(Contains);
        }

        public bool ContainsSome(Region region) {
            var regionPoints = region.Points;
            return ContainsSome(regionPoints);
        }

        public IEnumerable<Point> Points {
            get {
                for (var x = Point.X; x < Point.X + Size.Width; ++x)
                    for (var y = Point.Y; y < Point.Y + Size.Height; ++y)
                        yield return new Point(x, y);
            }
        }
        public bool Contains(Point point) {
            if (!(point.X >= _point.X && point.X < (_point.X + _size.Width)))
                return false;

            return (point.Y >= _point.Y && point.Y < (_point.Y + _size.Height));
        }

        public static IEnumerable<Point> operator - (Region region1, Region region2) {
            var pointsRegion1 = region1.Points;
            var pointsRegion2 = region2.Points;

            return pointsRegion1.Except(pointsRegion2);
        }


        public override string ToString() {
            return string.Format("Left corner {0} width size {1}", Point, Size);
        }
    }
}
