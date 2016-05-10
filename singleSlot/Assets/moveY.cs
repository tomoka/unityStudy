using UnityEngine;
using System.Collections;

public class moveY : MonoBehaviour {
	private float y;
	private float x;

	// Use this for initialization
	void Start () {
		y = this.transform.position.y;
		x = this.transform.position.x;
		this.transform.position = new Vector3(x,y,10);
	}
	
	// Update is called once per frame

	void Update () {
		if(!scoreAdd.stopFlag){
			y = y - (0.1f * 2);
		}

		this.transform.position = new Vector3(x,y,10);
		if(this.transform.position.y < -3.4){
			Destroy(this.gameObject);
		}
	}
	void test(){
		Debug.Log("test()");	
		Debug.Log(this.transform.name);	
	}
}