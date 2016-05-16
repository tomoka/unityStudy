using UnityEngine;
using System.Collections;
using System;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;
	public GameObject retObj;
	public static GameObject preObj;

	public int count;
	private float timerNow;
	private float timerPass;
	private float waitTime;
	private float datetimeStr;

	void Start () {
		count = 0;
		waitTime = 1f;
		datetimeStr = Time.time;

		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			//objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}
		retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "Obj" + (count++);
		retObj.transform.position = new Vector3(0,12.5f,10);
		retObj.transform.parent = gameObject.transform;
		preObj = retObj;

		retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "Obj" + (count++);
		retObj.transform.position = new Vector3(0,7,10);
		retObj.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update (){
		Debug.Log(Screen.dpi);
		timerNow = Time.time;
		timerPass = timerNow - datetimeStr;
		//timer += Time.deltaTime;
		//Debug.Log("Time.time--->" + Time.time);
		if (timerPass > waitTime) {
			//do something.
			//Invoke("example",0);
			datetimeStr = Time.time;
		}
		if (preObj) {
			if (preObj.transform.position.y < 2) {
			//do something.
			Invoke("example",0);
			}
		}
		//Score.score++;
	}

	void example() {
		if(!scoreAdd.stopFlag){
			retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
			retObj.transform.name = "Obj" + (count++);
			retObj.transform.position = new Vector3(0,7,10);
			retObj.transform.parent = gameObject.transform;
			preObj = retObj;

			//var sr = retObj.GetComponent<SpriteRenderer>();
			//var width = sr.bounds.size.x;
			//var height = sr.bounds.size.y;

			//Debug.Log("sr.bounds.size.x--->" + (width));
			//Debug.Log("sr.bounds.size.y--->" + (height));
			//Debug.Log("position--->" + retObj.transform.position);
			//Debug.Log("right---->" + retObj.transform.right);
			//Debug.Log("localScale---->" + retObj.transform.localScale);
		}
	}
}
