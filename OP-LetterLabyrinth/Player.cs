/**
 * @(#) Player.cs
 */

using System;

namespace OP_LetterLabyrinth
{
    public class Player
    {
        private Point _position;

        public Player(Point point)
        {
            _position = point;
        }
	
        public Point GetPosition(  )
        {
            return _position;
        }
	
        public Point Move( Move move )
        {
            switch (move)
            {
                case OP_LetterLabyrinth.Move.Right:
                    _position.Y++;
                    break;
                case OP_LetterLabyrinth.Move.Down:
                    _position.X++;
                    break;
                case OP_LetterLabyrinth.Move.Left:
                    _position.Y--;
                    break;
                case OP_LetterLabyrinth.Move.Up:
                    _position.X--;
                    break;
            }
            return _position;
        }
    }
}