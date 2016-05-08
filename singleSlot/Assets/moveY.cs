using UnityEngine;
using System.Collections;

public class moveY : MonoBehaviour {
	public float y;

	// Use this for initialization
	void Start () {
		y = 8;
		this.transform.position = new Vector3(2,y,10);
	}
	
	// Update is called once per frame

	void Update () {
		if(!scoreAdd.stopFlag){
			y = y - (0.1f * 2);
		}

		this.transform.position = new Vector3(2,y,10);
		if(transform.position.y < -6){
			Destroy(gameObject);
		}
	}
	void test(){
		Debug.Log("test()");	
		Debug.Log(this.transform.name);	
	}
}