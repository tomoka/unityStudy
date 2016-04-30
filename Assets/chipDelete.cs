using UnityEngine;
using System.Collections;

public class chipDelete : MonoBehaviour {

	public float life_time = 4f;
	float time = 0f;

	// Use this for initialization
	void Start () {
		print (Time.deltaTime);
		print (time);
		time = 0f;
		life_time = (4f * Random.value) + 4f;
	}

	// Update is called once per frame
	void Update () {
		print ("life_time------>" + life_time);
		if(time>life_time){
			//time = 0f;
			Destroy(gameObject);
		}
		time = time + Time.deltaTime;
	}
}
