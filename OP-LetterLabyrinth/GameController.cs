/**
 * @(#) GameController.cs
 */

using System;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class GameController
    {
        private LetterGrid _currentGrid;
        private Player _currentPlayer;
        private IInput _input;
        private IGraphics _graphics;
        private Dictionary _currentDictionary;

        public void InstanciateGame(LanguageName language,
            IInput input, IGraphics graphics, int sizeX, int sizeY)
        {
            Logger.GetInstance().Log("INFO", $"Starting game. Grid: {sizeX}:{sizeY}. Language : {language}");
            var lang = new Language(language, language + "_dictionary.txt");
            ResetGameStatus(lang);
            _currentDictionary = new Dictionary(lang);
            _currentPlayer = new Player(new Point { X = -1, Y = 0 });
            _currentGrid = new LetterGrid(sizeX, sizeY, new SmartGridFiller(_currentDictionary));
            _input = input;
            _graphics = graphics;
            _graphics.DrawTurn(_currentPlayer, _currentGrid, _currentDictionary);
        }

        private static void ResetGameStatus(Language language)
        {
            Logger.GetInstance().Log("INFO", "Reseting game");
            GameStatus.GetInstance().ClearCurrentWord();
            GameStatus.GetInstance().ResetPoints();
            GameStatus.GetInstance().SetLanguage(language);
        }

        public void PerformNextTurn(int turnNumber)
        {
            Logger.GetInstance().Log("INFO", $"Performing turn {turnNumber}");
            var move = _input.GetNewDirection();
            var position = _currentPlayer.Move(move);
            var letter = _currentGrid.ConsumeLetterAt(position);
            if (move != Move.Drop)
            {
                var currentWord = GameStatus.GetInstance().AddLetter(letter);
                if (_currentDictionary.AnyWordBeginsWith(currentWord))
                {
                    if (_currentDictionary.WordFragmentExistsInPath(currentWord))
                    {
                        if (_currentDictionary.WordExistsInPath(currentWord))
                        {
                            GameStatus.GetInstance().ConsumeCurrentWord(true);
                        }
                    }
                    else
                    {
                        if (currentWord.Length > 2 && _currentDictionary.WordExists(currentWord))
                        {
                            GameStatus.GetInstance().ConsumeCurrentWord(true);
                        }
                    }
                }
                else
                {
                    GameStatus.GetInstance().ConsumeCurrentWord(false);
                }
            }
            else
            {
                GameStatus.GetInstance().ConsumeCurrentWord(false);
            }
            _graphics.DrawTurn(_currentPlayer, _currentGrid, _currentDictionary);
        }

        public void FinishGame()
        {
            Logger.GetInstance().Log("INFO", "Ending game");
        }

        public bool HasGameFinished()
        {
            return false;
        }
    }
}

