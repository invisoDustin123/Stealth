using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public float speed;
	public bool makingNoise = false;
	private Transform tf;


	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {

			Vector3 movement = tf.position;

			if (Input.GetKey ("a")) {
				movement.x -= speed;
			}
			if (Input.GetKey ("d")) {
				movement.x += speed;
			}
			if (Input.GetKey ("w")) {
				movement.y += speed;
			}
			if (Input.GetKey ("s")) {
				movement.y -= speed;
			}

			if (tf.position != movement) {
				makingNoise = true;
			} else {
				makingNoise = false;
			}

			tf.position = movement;

			Vector3 mouseScreen = Input.mousePosition;
			Vector3 mouse = Camera.main.ScreenToWorldPoint (mouseScreen);

			tf.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (mouse.y - tf.position.y, mouse.x - tf.position.x) * Mathf.Rad2Deg);

		}
	}
}
