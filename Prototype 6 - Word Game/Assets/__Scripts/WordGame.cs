using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum GameMode {
	preGame, // Before the game starts
	loading, // The word list is loading and being parsed
	makeLevel, // The individual WordLevel is being created
	levelPrep, // The level visuals are being Intantiated
	inLevel // The level is in progress
}

public class WordGame : MonoBehaviour {
	static public WordGame S; // Singleton

	[Header("Set Dynamically")]
	public GameMode mode = GameMode.preGame;
	public WordLevel currLevel;
	
	void Awake() {
		S = this; // Assign the Singleton
	}
	
	void Start () {
		mode = GameMode.loading;
		
		// Call the static Init() method of WordList
		WordList.INIT();
	}

	public void WordListParseComplete() {
		mode = GameMode.makeLevel;
		currLevel = MakeWordLevel();
	}

	public WordLevel MakeWordLevel(int levelNum = -1) {
		WordLevel level = new WordLevel();
		if (levelNum == -1) {
			// Pick random level
			level.longWordIndex = Random.Range(0, WordList.LONG_WORD_COUNT);
		}
		else {
			// This will be added later in the chapter
		}

		level.levelNum = levelNum;
		level.word = WordList.GET_LONG_WORD(level.longWordIndex);
		level.charDict = WordLevel.MakeCharDict(level.word);

		StartCoroutine(FindSubWordsCoroutine(level));

		return level;
	}
	
	// A coroutine that finds words that can be spelled in this level
	public IEnumerator FindSubWordsCoroutine(WordLevel level) {
		level.subWords = new List<string>();
		string str;

		List<string> words = WordList.GET_WORDS();
		
		// Iterate through all of the words in the wordList
		for (int i = 0; i < WordList.WORD_COUNT; i++) {
			str = words[i];
			// Check whether each one can be spelled using level.charDict
			if (WordLevel.CheckWordInLevel(str, level)) {
				level.subWords.Add(str);
			}
			// Yield if we have parsed a lot of words this frame
			if (i % WordList.NUM_TO_PARSE_BEFORE_YIELD == 0) {
				// yield until the next frame
				yield return null;
			}
		}
		
		level.subWords.Sort();
		level.subWords = SortWordsByLength(level.subWords).ToList();
		
		// The coroutine is complete, so call SubWordSearchComplete()
		SubWordSearchComplete();
	}
	
	// Use LINQ to sort the array and return a copy
	public static IEnumerable<string> SortWordsByLength(IEnumerable<string> ws) {
		ws = ws.OrderBy(s => s.Length);
		return ws;
	}

	public void SubWordSearchComplete() {
		mode = GameMode.levelPrep;
	}
}
