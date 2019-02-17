using System;
using Ixmucane.Puzzle;

namespace PuzzelConsole {
    class Program {
        static void Main() {
            var puzzle = BoardFactory.CreateRedDonkeyPuzzle(); //8s and 114 moves
            //var puzzle = BoardFactory.CreateSimpleTrafficJamPuzzle(); //?s and 82 moves
            //var puzzle = BoardFactory.CreateCenturyBoard(); // 14s 131moves
            //var puzzle = BoardFactory.CreateSuperCenturyBoard(); //12s  179moves

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine(DateTimeOffset.UtcNow);

            var someSuperIntelligentPerson = new SomeSuperIntelligentPerson();

            var solution = someSuperIntelligentPerson.SolvePuzzle(puzzle);

            var solutionViewer = new SolutionViewer();
            solutionViewer.ShowSolution(puzzle, solution);

        }
    }
}
