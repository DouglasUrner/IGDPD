using System.Collections;
using System.Collections.Generic;
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
		
	}
}
