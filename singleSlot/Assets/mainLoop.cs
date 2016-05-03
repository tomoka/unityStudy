using UnityEngine;
using System.Collections;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;

	void Start () {

		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
