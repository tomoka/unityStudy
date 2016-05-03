using UnityEngine;
using System.Collections;

public class moveY : MonoBehaviour {

	// Use this for initialization
	///void Start () {
	
	//}
	
	// Update is called once per frame
	public float y;

	void Update () {
		y --;
		transform.position = new Vector3
			(
			transform.position.x, 
			//Mathf.PingPong(Time.time,5), 
			y, 
			transform.position.z
		);
		print("Time.time----->" + Time.time);
		print(Mathf.PingPong(Time.time,5));

		if(transform.position.y < -6){
			y = 6;
		}

	}
}
