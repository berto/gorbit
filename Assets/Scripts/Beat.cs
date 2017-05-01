using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

	private float baseSize = 3;
	private float baseSpeed = 0.5f;

	void Update() {
		float x = baseSize + Mathf.PingPong (Time.time * baseSpeed, 1);
		float y = baseSize + Mathf.PingPong (Time.time * baseSpeed, 1);
		transform.localScale = new Vector3(x, y, transform.localScale.z);
	}
}
