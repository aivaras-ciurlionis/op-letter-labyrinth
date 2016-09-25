using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class RandomGridFiller : IGridFiller
    {
        private Dictionary _dictionary;

        public RandomGridFiller(Dictionary dictionary)
        {
            _dictionary = dictionary;
        }

        private Letter GetLetterInFrequencyIndex(IEnumerable<Letter> letters, int index)
        {
            var sum = 0;
            foreach (var letter in letters)
            {
                sum += letter.GetFrequency();
                if (sum >= index)
                {
                    return letter;
                }
            }
            return letters.First();
        }

        public List<List<Letter>> GetLetters(int sizeX, int sizeY)
        {
            var letters = _dictionary.GetLetters();
            var orderedLetters = letters.OrderBy(l => l.GetFrequency());
            var totalFrequency = letters.Sum(l => l.GetFrequency());
            var random = new Random();
            var list = new List<List<Letter>>();
            for (var i = 0; i < sizeX; i++)
            {
                var rowList = new List<Letter>();
                for (var j = 0; j < sizeY; j++)
                {
                    rowList.Add(GetLetterInFrequencyIndex(orderedLetters, random.Next(totalFrequency)));
                }
                list.Add(rowList);
            }
            return list;
        }
    }
}