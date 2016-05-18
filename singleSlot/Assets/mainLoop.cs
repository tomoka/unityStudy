using UnityEngine;
using System.Collections;
using System;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;
	public static GameObject retObj;
	public static GameObject preObj;

	public int count;
	private float timerNow;
	private float timerPass;
	private float waitTime;
	private float datetimeStr;

	public static float slotItemY;

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
		retObj.transform.position = new Vector3(0,2.5f,10f);
		retObj.transform.parent = gameObject.transform;
		preObj = retObj;

		retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "Obj" + (count++);
		retObj.transform.position = new Vector3(0,8f,10f);
		retObj.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update (){
		//Debug.Log(Screen.dpi);
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
			if (preObj.transform.position.y < 2.5f) {
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
			retObj.transform.position = new Vector3(0,8f,10f);
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
	public static void result(int num) {
		float stopPositionY = 0f;
		switch ( num ){
		case 1:
			Debug.Log("パー");
			stopPositionY = 3.5f;
			break;
		case 2:
			Debug.Log("チョキ");
			stopPositionY = 3.5f;
			break;
		case 3:
			Debug.Log("ぐー");
			stopPositionY = 3.5f;
			break;
		default:
			break;
		}

		iTween.MoveTo (preObj, iTween.Hash(
			"y", stopPositionY,
			"time", 1f,
			"easeType", "easeInOutBack"
		));

		iTween.MoveTo (retObj, iTween.Hash(
			"y", stopPositionY,
			"time", 1f,
			"easeType", "easeInOutBack"
		));

	}
}
