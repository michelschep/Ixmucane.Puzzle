using System.Collections.Generic;
using NUnit.Framework;

namespace Ixmucane.Puzzle.Test {
    [TestFixture]
    class RegionTest {
        [Test]
        public void When_two_identical_regions_are_substracted_then_result_is_empty() {
            var region1 = new Region(Point.For(0, 0), new Size(1, 1));
            var region2 = new Region(Point.For(0, 0), new Size(1, 1));

            var points = region1 - region2;

            Assert.That(points, Is.Empty, "Substraction");
        }

        [Test]
        public void When_two_seperate_regions_are_substracted_then_result_is_first_region() {
            var region1 = new Region(Point.For(0, 0), new Size(1, 1));
            var region2 = new Region(Point.For(1, 0), new Size(1, 1));

            var points = region1 - region2;

            Assert.That(points, Is.EqualTo(region1.Points), "Substraction");
        }

        [Test]
        public void When_two_overlapping_regions_are_substracted_then_result_is_difference() {
            var region1 = new Region(Point.For(0, 0), new Size(2, 1));
            var region2 = new Region(Point.For(1, 0), new Size(1, 1));

            var points = region1 - region2;

            Assert.That(points, Is.EqualTo(new List<Point> {Point.For(0, 0)}), "Substraction");
        }
    }
}
