using System;
using System.Collections.Generic;
using System.Threading;

namespace Ixmucane.Puzzle {
    public class SolutionViewer {
        public void ShowSolution(Board puzzle, BoardHistory solution) {
            var index = 1;
            foreach (var puzzleMove in solution.Moves) {
                Console.WriteLine("{0}. {1}", index++, puzzleMove);
            }
            Console.WriteLine();
            Console.WriteLine("Press the ANY key");
            Console.ReadLine();


            var map = new Dictionary<Piece, ConsoleColor>();

            var queue = new Queue<ConsoleColor>();
            queue.Enqueue(ConsoleColor.Green);
            queue.Enqueue(ConsoleColor.DarkGreen);
            queue.Enqueue(ConsoleColor.DarkBlue);
            queue.Enqueue(ConsoleColor.Blue);
            queue.Enqueue(ConsoleColor.Cyan);
            queue.Enqueue(ConsoleColor.DarkCyan);
            queue.Enqueue(ConsoleColor.Magenta);
            queue.Enqueue(ConsoleColor.DarkMagenta);
            queue.Enqueue(ConsoleColor.Yellow);
            queue.Enqueue(ConsoleColor.DarkYellow);

            foreach (var piece in puzzle.Pieces) {
                if (piece.Size.Equals(new Size(2, 2)))
                    map.Add(piece, ConsoleColor.Red);
                else {
                    map.Add(piece, queue.Dequeue());
                }
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.CursorTop = 0;
            WriteBoard(puzzle, map);
            Console.ReadLine();

            Console.CursorTop = 0;

            foreach (var puzzleMove in solution.Moves) {
                puzzle.MovePiece(puzzleMove.Piece, puzzleMove.MoveType);
                WriteBoard(puzzle, map);
                Console.CursorTop = 0;
                Console.BackgroundColor = ConsoleColor.Black;
                //Thread.Sleep(200);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void WriteBoard(Board puzzle, Dictionary<Piece, ConsoleColor> map) {
            var size = 12;
            for (var y = 0; y < puzzle.BoardRegion.Size.Height; ++y) {
                for (var s = 0; s < size; ++s) {
                    for (var x = 0; x < puzzle.BoardRegion.Size.Width; ++x) {
                        var piece = puzzle.GetPiece(Point.For(x, y));

                        if (piece == null) {
                            Console.BackgroundColor = ConsoleColor.Black;
                        } else {
                            Console.BackgroundColor = map[piece];
                        }
                        for (var b = 1; b < size; ++b)
                            Console.Write("   ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}