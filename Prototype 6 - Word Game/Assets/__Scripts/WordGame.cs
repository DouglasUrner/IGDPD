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

	[Header("Set in Inspector")]
	public GameObject prefabLetter;
	public Rect wordArea = new Rect(-24, 19, 48, 28);
	public float letterSize = 1.5f;
	public bool showAllWyrds = true;
	
	[Header("Set Dynamically")]
	public GameMode mode = GameMode.preGame;
	public WordLevel currLevel;
	public List<Wyrd> wyrds;

	private Transform letterAnchor, bigLetterAnchor;
	
	void Awake() {
		S = this; // Assign the Singleton
		letterAnchor = new GameObject("LetterAnchor").transform;
		bigLetterAnchor = new GameObject("BigLetterAnchor").transform;
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
		Layout(); // Call the Layout() function once the WordSearch is done
	}

	void Layout() {
		// Place the letters for each subword of currLevel on screen
		wyrds = new List<Wyrd>();
		
		// Declare a lot of local variables that will be used in this method
		GameObject go;
		Letter lett;
		string word;
		Vector3 pos;
		float left = 0;
		float columnWidth = 3;
		char c;
		Color col;
		Wyrd wyrd;
		
		// Determine how many rows of Letters will fit on the screen
		int numRows = Mathf.RoundToInt(wordArea.height / letterSize);

		for (int i = 0; i < currLevel.subWords.Count; i++) {
			wyrd = new Wyrd();
			word = currLevel.subWords[i];
			
			// if the word is longer than columnWidth, expand it
			columnWidth = Mathf.Max(columnWidth, word.Length);
			
			// Instantiate a PrefabLetter for each letter of the word
			for (int j = 0; j < word.Length; j++) {
				c = word[j]; // Grab the jth character of the word
				go = Instantiate<GameObject>(prefabLetter);
				go.transform.SetParent(letterAnchor);
				lett = go.GetComponent<Letter>();
				lett.c = c;
				
				// Position the Letter
				pos = new Vector3(wordArea.x + left + j * letterSize, wordArea.y, 0);
				
				// The % here makes multiple columns line up
				pos.y -= (i % numRows) * letterSize;

				lett.pos = pos;

				go.transform.localScale = Vector3.one * letterSize;
				
				wyrd.Add(lett);
			}

			if (showAllWyrds) wyrd.visible = true;

			wyrds.Add(wyrd);
			
			// If we've gotton to the numRows(th) row, start a new column
			if (i % numRows == numRows - 1) {
				left += (columnWidth + 0.5f) * letterSize;
			}
		}
	}
}
