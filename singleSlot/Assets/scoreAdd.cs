using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ButtonPush() { // MUST public
		Debug.Log ("clicked");
		if(!stopFlag){
			stopFlag = true;
			Score.score++;
		}
	}
}
