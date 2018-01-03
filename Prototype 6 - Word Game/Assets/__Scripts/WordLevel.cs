using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]				// WordLevels can be viewed & edited in the Inspector
public class WordLevel {		// WordLevel does NOT extend MonoBehavior
	public int levelNum;
	public int longWordIndex;
	public string word;
	// A Dictionary<,> of all of the letters in the word
	public Dictionary<char, int> charDict;
	public List<string> subWords;
	
	// A static function that counts the instancets of chars in a string and
	// returns a Dictionary<char, int> that contains this information
	static public Dictionary<char, int> MakeCharDict(string w) {
		Dictionary<char, int> dict = new Dictionary<char, int>();
		char c;
		for (int i = 0; i < w.Length; i++) {
			c = w[i];
			if (dict.ContainsKey(c)) {
				dict[c]++;
			} else {
				dict.Add(c, 1);
			}
		}
		return dict;
	}
	
	// This static method checks to see whether a word can be spelled with the
	// chars in level.charDict
	public static bool CheckWordInLevel(string str, WordLevel level) {
		Dictionary<char, int> counts = new Dictionary<char, int>();

		for (int i = 0; i < str.Length; i++) {
			char c = str[i];
			// If charDict contains char c
			if (level.charDict.ContainsKey(c)) {
				if (!counts.ContainsKey(c)) {
					// ...then adda new key with a value of 1
					counts.Add(c, 1);
				} else {
					// Otherwise, add 1 to the current value
					counts[c]++;
				}
				if (counts[c] > level.charDict[c]) {
					return false;
				}
			} else {
				return false;
			}
		}
		return true;
	}
}
