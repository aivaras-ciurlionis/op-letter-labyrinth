using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class Dictionary
    {
        private readonly Language _language;
        private readonly string[] _words;
        private List<Letter> _letters = new List<Letter>();

        public Dictionary(Language language)
        {
            _language = language;
            IDictionaryReader reader = new DictionaryReader(_language.GetDictionaryLocation());
            _words = reader.GetAllWords();
            _letters.AddRange(reader.GetAllLetters().ToList());
        }

        public bool WordExists(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToLower();
            return _words.Any(w => w == stringWord);
        }

        public bool AnyWordBeginsWith(Letter[] fragment)
        {
            var stringFragment = StringFromLetters(fragment).ToLower();
            return _words.Any(w => w.StartsWith(stringFragment));
        }

        public string GetAnyWordOfLength(int length)
        {
            var possibleWords = _words.Where(w => w.Length == length);
            var random = new Random();
            var enumerable = possibleWords as string[] ?? possibleWords.ToArray();
            var word = enumerable.ElementAt(random.Next(enumerable.Length)).ToUpper();
            Logger.GetInstance().Log("INFO", $"Getting word of {length} length: {word}");
            return word;
        }

        public Language GetLanguage()
        {
            return _language;
        }
        public Letter[] GetLettersOfWord(string word)
        {
            return word.Select(letter => _letters.First(l => l.GetName() == letter.ToString())).ToArray();
        }

        private static string StringFromLetters(Letter[] letters)
        {
            return letters.Aggregate("", (s, letter) => s+=letter.GetName());
        }

        public Letter[] GetLetters()
        {
            return _letters.ToArray();
        }
    }
}
