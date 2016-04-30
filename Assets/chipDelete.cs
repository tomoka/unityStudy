using UnityEngine;
using System.Collections;

public class chipDelete : MonoBehaviour {

	public float life_time = 4f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		print (Time.deltaTime);
		print (time);
		this.time = 0f;
		this.life_time = (4f * Random.value) + 1f;
	}

	// Update is called once per frame
	void Update () {
		print ("this.life_time------>" + this.life_time);
		print ("life_time------>" + life_time);
		if(this.time > this.life_time){
			//time = 0f;
			Destroy(gameObject);
		}
		this.time = this.time + Time.deltaTime;
	}
}
