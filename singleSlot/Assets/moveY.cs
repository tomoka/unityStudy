using UnityEngine;
using System.Collections;

public class moveY : MonoBehaviour {
	public float y;

	// Use this for initialization
	void Start () {
		y = 8;
		this.transform.position = new Vector3(0,y,10);
	}
	
	// Update is called once per frame

	void Update () {
		y = y - 1;
		this.transform.position = new Vector3(0,y,10);
		if(transform.position.y < -6){
			Destroy(gameObject);
		}
	}
	void test(){
		Debug.Log("test()");	
		Debug.Log(this.transform.name);	
	}
}