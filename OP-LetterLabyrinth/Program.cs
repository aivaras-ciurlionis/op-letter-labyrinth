using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_LetterLabyrinth
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.GetInstance().Log("INFO", "Program is starting");
            var game = new GameController();
            game.InstanciateGame(LanguageName.En, new SimpleInput(), new ConsoleGraphics(), 15, 15);
            var turn = 0;
            while (true)
            {
                turn++;
                game.PerformNextTurn(turn);
            }
        }
    }
}
