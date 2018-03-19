using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadBehavior : MonoBehaviour {

	public GameObject target;
	public GameObject can;
	public int State = 0;
	public float fov = 90;
	public float speed;

	private int timer = 180;
	private bool dir = false;
	private Vector3 heardPosition;
	private Vector3 movement;

	private Text c;

	private Transform tf;

	void Vision() {
		Debug.DrawLine (tf.position, tf.position + (2 * tf.right - 2 * tf.up));
		Debug.DrawLine (tf.position, tf.position + (2 * tf.right + 2 * tf.up));
		Debug.DrawLine (tf.position, tf.position + (2.8f * tf.right));
		if (Vector3.Distance (tf.position, target.transform.position) < 2.8) {
			if (Vector3.Angle (target.transform.position - tf.position, tf.right) < fov / 2) {
				RaycastHit2D hit = Physics2D.Raycast (tf.position, target.transform.position);
				if (hit.collider == null) { 
					Debug.Log ("null");
				} else if (hit.collider.gameObject == target.gameObject) {
					
					//if see player, go to state 1
					State = 2;
					Debug.Log (target.transform.position - tf.position);
					Debug.Log (tf.right);
					Debug.Log (Vector3.Distance (tf.position, target.transform.position));
				}
			}
		}
	}

	void Listen() {
		if (target.GetComponent<PlayerBehavior> ().makingNoise) {
			if (Vector3.Distance (tf.position, target.transform.position) < 6) {
				heardPosition = target.transform.position;
				State = 1;
			}
		}
	}

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		c = can.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			timer -= 1;
			if (timer <= 0) {
				timer = 180;
				dir = !dir;
			}

			switch (State) {
			case 0:
				c.text = "Patrolling";
				//patrol back and forth. 
				movement = tf.position;
				if (dir) {
					movement.x += speed;
				} else {
					movement.x -= speed;
				}
				tf.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (movement.y - tf.position.y, movement.x - tf.position.x) * Mathf.Rad2Deg);
				tf.position = movement;

				//check for seeing player
				Vision ();

				//listen for player
				Listen ();

				break;
			case 1:
				//investigate
				c.text = "Seeking";

				tf.position = Vector3.MoveTowards (tf.position, heardPosition, speed);
				tf.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (heardPosition.y - tf.position.y, heardPosition.x - tf.position.x) * Mathf.Rad2Deg);
				if (tf.position == heardPosition) {
					State = 0;
				}

				Vision ();
				Listen ();
				break;
			case 2:
				//chase player
				//if player is too far or player is dead
				//go to state 0 again
				break;
			}
		}
	}
}
