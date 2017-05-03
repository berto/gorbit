using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

	void Awake() {
		transform.RotateAround (transform.position, transform.right, 180f);
	}
}
