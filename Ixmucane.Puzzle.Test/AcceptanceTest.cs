using NUnit.Framework;

namespace Ixmucane.Puzzle.Test {
    [TestFixture]
    public class AcceptanceTest {
        [Test, Ignore]
        public void SolvePuzzle() {
            var board = BoardFactory.CreateRedDonkeyPuzzle();

            var someSuperIntelligentPerson = new SomeSuperIntelligentPerson();

            var solution = someSuperIntelligentPerson.SolvePuzzle(board);

            var solutionViewer = new SolutionViewer();
            solutionViewer.ShowSolution(board, solution);
        }
    }
}