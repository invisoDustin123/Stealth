using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour 
{
	public GameObject GameManager;

	// Use this for initialization
	void Start () {
		Pause ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	
	public void Pause()
	{

		if (GameManager.GetComponent<GameManager> ().State == 0) {
			GameManager.GetComponent<GameManager> ().State = 1;
		} 
		else 
		{
			GameManager.GetComponent<GameManager> ().State = 0;
		}
			

		Debug.Log ("Hello");
	}
}
