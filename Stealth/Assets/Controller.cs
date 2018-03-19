using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	void ToggleControl() {
		if (gameObject.GetComponent<BadBehavior> ().enabled) {
			gameObject.GetComponent<BadBehavior> ().enabled = false;
			gameObject.GetComponent<PlayerBehavior> ().enabled = true;
		} else {
			gameObject.GetComponent<BadBehavior> ().enabled = true;
			gameObject.GetComponent<PlayerBehavior> ().enabled = false;
		}
	}

}
