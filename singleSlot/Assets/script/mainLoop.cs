using UnityEngine;
using System.Collections;
using System;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;
	public GameObject canvas;
	public static GameObject retObj;
	public static GameObject preObj;

	public int count;
	private float timerNow;
	private float timerPass;
	private float waitTime;
	private float datetimeStr;

	public static float slotItemY;

	public static float retObjY;
	public static float preObjY;

	public static int stopFlagCount = 0;

	public static float stopPositionY01;
	public static float stopPositionY02;

	public static float speed = 1f;

	void Start () {
		count = 0;
		waitTime = 0;
		datetimeStr = Time.time;

		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			//objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}
		//前
		preObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		preObj.transform.name = "Obj02";
		preObj.transform.position = new Vector3(0,8f,0f);
		preObj.transform.parent = GameObject.Find("canvas").transform;

		//次
		retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "Obj01";
		retObj.transform.position = new Vector3(0,2.47f,0f);
		retObj.transform.parent = GameObject.Find("canvas").transform;
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
			if (preObj.transform.position.y < 2.47f) {
			//do something.
			Invoke("example",0);
			}
		}

		if(speed < 2 && !scoreAdd.stopFlag){
			speed = speed + (speed * 0.01f) + 0.001f;
		}else if(speed > 0 && scoreAdd.stopFlag){
			speed = speed - (speed * 0.01f);
			if(speed < 0.02f){
				speed = 0;
				Invoke("result",0);
				Debug.Log("リザルト");
			}
		}


	}

	void example() {
		if(!scoreAdd.stopFlag){
			retObj = preObj;
			retObj.transform.name = "Obj01";

			preObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
			preObj.transform.name = "Obj02";
			preObj.transform.position = new Vector3(0,8f,0f);
			preObj.transform.parent = GameObject.Find("canvas").transform;

		}else{
			retObj = preObj;
			retObj.transform.name = "Obj01";

			preObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
			preObj.transform.name = "Obj02";
			preObj.transform.position = new Vector3(0,8f,0f);
			preObj.transform.parent = GameObject.Find("canvas").transform;

		}
		Debug.Log("example");
	}
	void result() {
		float positionY01 = 1f;
		float positionY02 = 2f;
		int num = 1;

		//上の画像の位置で表示内容を判定
		var positionY = mainLoop.preObj.transform.position.y;

		/*
		 * パー = (4.5~2.5)(-3.5~6.5)|(1.6~3.14)
		 * チョキ = (2.5~0.5)(-1.5~-3.5)|(-0.25~1.56)(6.5~8.0)
		 * グー = (6.5~4.5)(0.5~-1.5)|(3.14~5.14)
		 */

		//上のパー
		if (positionY >= 0.9 && positionY < 2.35) {
			num = (int)1;
			Debug.Log("パー");

			positionY01 = -4.4f;
			positionY02 = 1.13f;
		}
		//下のチョキ
		else if (positionY >= 4.29 && positionY < 6.13) {
			num = (int)2;
			Debug.Log("チョキ");

			positionY01 = -0.75f;
			positionY02 = 4.73f;
		}
		//上のグー
		else if (positionY >= 2.35 && positionY < 4.29) {
			num = (int)3;
			Debug.Log("ぐー");

			positionY01 = -2.63f;
			positionY02 = 2.9f;
		}
		//下のパー（この表示だけありうる）
		else if (positionY >= 6.13) {
			num = (int)1;
			Debug.Log("パー2");

			positionY01 = 1.03f;
			positionY02 = 6.59f;
		}

		Score.score++;
		switch(num){
		case 1:
			ParCounter.parCount++;
			break;
		case 2:
			ChokiCounter.chokiCount++;
			break;
		case 3:
			GooCounter.gooCount++;
			break;
		}

		Debug.Log ("num----->" + num);

		//mainLoop.result(num,positionY01,positionY02);
		//次のオブジェクト
		iTween.MoveTo (preObj, iTween.Hash(
			"y", positionY02,
			"time", 1f,
			"easeType", "easeInOutQuad"
		));

		//前のオブジェクト
		iTween.MoveTo (retObj, iTween.Hash(
			"y", positionY01,
			"time",1f,
			"easeType", "easeInOutQuad"
		));

		Debug.Log ("positionY01----->" + positionY01);
		Debug.Log ("positionY02----->" + positionY02);

		}
	}
