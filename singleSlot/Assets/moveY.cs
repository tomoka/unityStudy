using UnityEngine;
using System.Collections;

public class moveY : MonoBehaviour {
	private float y;

	// Use this for initialization
	void Start () {
		y = 4;
		this.transform.position = new Vector3(2,y,10);
	}
	
	// Update is called once per frame

	void Update () {
		if(!scoreAdd.stopFlag){
			y = y - (0.1f * 2);
		}

		this.transform.position = new Vector3(2,y,10);
		if(this.transform.position.y < -3.4){
			Destroy(this.gameObject);
		}
	}
	void test(){
		Debug.Log("test()");	
		Debug.Log(this.transform.name);	
	}
}