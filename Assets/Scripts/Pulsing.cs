using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsing : MonoBehaviour {

	private Text text;
	private Color colorT = Color.red;

	void Update () {
		text = gameObject.GetComponent<Text> ();
		text.color = new Color(text.color.r,text.color.g,text.color.b, Mathf.PingPong(Time.time, 2.0f));
	}
		
}
