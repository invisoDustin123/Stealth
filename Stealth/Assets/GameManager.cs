using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int GameState;
	public static GameManager gm;
	public bool gameIsStarted;
	public GameObject Player;
	public int State = 1;
	void Awake () {
		if (gm == null) {
			gm = this;
		} else {
			Destroy (gameObject);
		}
	}



	// Use this for initialization
	void Start () {
		gameIsStarted = false;
	}

	// Update is called once per frame
	void Update () {

		switch (State) {

		case 0: 
			Time.timeScale = 0;
			//Debug.Log (Time.timeScale);
		//running
			break;

		case 1:
			Time.timeScale = 1;
			//Debug.Log (Time.timeScale); 
			break;
		}

	}
}
