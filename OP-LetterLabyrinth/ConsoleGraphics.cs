/**
 * @(#) ConsoleGraphics.cs
 */

using System;

namespace OP_LetterLabyrinth
{
    public class ConsoleGraphics : IGraphics
    {
        public void DrawTurn(Player player, LetterGrid grid)
        {
            Console.Clear();
            Console.WriteLine(grid.ToString());
            Console.WriteLine();
            Console.WriteLine(GameStatus.GetInstance().ToString());
        }
    }
}
