using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramPuzzle.Model
{
    public class Anagram
    {
        protected string _baseWord;
        protected Dictionary<string, bool> _wordsMemo;
        public Anagram(string baseWord)
        {
            _baseWord = baseWord;
        }

        private Dictionary<char, int> GetDic(string word)
        {
            Dictionary<char, int> _letters = new Dictionary<char, int>();
            var words = word.ToCharArray();
            foreach (var w in words)
            {
                if (_letters.ContainsKey(w))
                {
                    _letters[w] = _letters[w] + 1;
                }
                else
                {
                    _letters.Add(w, 1);
                }
            }
            return _letters;
        }

        private bool IsAnagram(string word)
        {
            var dic = GetDic(_baseWord);
            var i = 0;
            while (i < word.Length) //abca
            {
                if (dic.ContainsKey(word[i]))
                {
                    dic[word[i]]--;
                }
                else
                    return false;
                i++;
            }
            return dic.All(x => x.Value == 0);
        }

        public List<string> FindAnagrams(List<string> words)
        {
            var response = new List<string>();
            foreach(var word in words)
            {
                if(_wordsMemo.ContainsKey(word))
                {
                    if (_wordsMemo[word])
                        response.Add(word);
                } else
                {
                    var result = IsAnagram(word);
                    _wordsMemo.Add(word, result);
                    if (result)
                        response.Add(word);
                }
                
            }

            return response;
        }
    }
}
