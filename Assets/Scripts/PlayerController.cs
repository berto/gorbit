using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private bool stopped;
	private bool isColliding;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * speed);
	}

	void NextLevel() {
		GameManager.instance.NextLevel ();
	}

	void PreviousLevel() {
		GameManager.instance.PreviousLevel ();
	}

	void Restart() {
		GameManager.instance.Reset ();
	}

	void Stop() {
		rb.velocity = Vector3.zero;
		stopped = true;
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if(isColliding) return;
		isColliding = true;
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			NextLevel ();
		} else if (other.gameObject.CompareTag ("Environment")) {
			PreviousLevel ();
		}
	}

	void Update() {
		isColliding = false;
	}
}
