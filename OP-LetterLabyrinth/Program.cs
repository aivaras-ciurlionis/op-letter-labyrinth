using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_LetterLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.GetInstance().Log("INFO", "Program is starting");
            var game = new GameController();
            game.InstanciateGame(LanguageName.En, new SimpleInput(), new ConsoleGraphics(), 10, 10);
            var turn = 0;
            while (true)
            {
                turn++;
                game.PerformNextTurn(turn);
            }
        }
    }
}
