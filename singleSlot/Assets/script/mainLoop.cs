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

	public static float retObjY;
	public static float preObjY;

	public static int stopFlagCount = 0;

	public static float stopPositionY01;
	public static float stopPositionY02;


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
		preObj.transform.position = new Vector3(0,8f,10f);
		preObj.transform.parent = gameObject.transform;

		//次
		retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "Obj01";
		retObj.transform.position = new Vector3(0,2.5f,10f);
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

	}

	void example() {
		if(!scoreAdd.stopFlag){
			retObj = preObj;
			retObj.transform.name = "Obj01";

			preObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
			preObj.transform.name = "Obj02";
			preObj.transform.position = new Vector3(0,7.4f,10f);
			preObj.transform.parent = gameObject.transform;

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
	public static void result(int num,float positionY01,float positionY02) {
		stopPositionY01 = positionY01;
		stopPositionY02 = positionY02;

		/*switch ( num ){
		case 1:
			Debug.Log("パー");
			stopPositionY01 = -2.5f;
			stopPositionY02 = 2.5f;
			break;
		case 2:
			Debug.Log("チョキ");
			stopPositionY01 = 0.75f;
			stopPositionY02 = 6.25f;
			break;
		case 3:
			Debug.Log("ぐー");
			stopPositionY01 = -1.75f;
			stopPositionY02 = 4.25f;
			break;
		default:
			break;
		}*/

		if(scoreAdd.stopFlag){
			//StartCoroutine("objMoveY");
			}
		//次のオブジェクト
		iTween.MoveTo (preObj, iTween.Hash(
			"y", stopPositionY02,
			"time", 1f,
			"easeType", "easeInOutQuad"
		));

		//前のオブジェクト
		iTween.MoveTo (retObj, iTween.Hash(
			"y", stopPositionY01,
			"time",1f,
			"easeType", "easeInOutQuad"
		));

	}
	private IEnumerator objMoveY (){
			do{
			// 座標の移動
			retObjY = retObj.transform.position.y;
			preObjY = preObj.transform.position.y;
			retObjY = retObjY - (0.1f * 2);
			preObjY = preObjY - (0.1f * 2);

			retObj.transform.position = new Vector3(0,retObjY,0);
			preObj.transform.position = new Vector3(0,preObjY,0);

			if(retObj.transform.position.y < -3.4){
				Destroy(retObj);
				retObj = preObj;
				retObj.transform.name = "Obj01";

				//前
				preObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
				preObj.transform.name = "Obj02";
				preObj.transform.position = new Vector3(0,8f,10f);
				//preObj.transform.parent = gameObject.transform.root;
				stopFlagCount++;
			}
			}
			//()の中に"true"を入れれば無限ループの指定。無限ループしない時は下記のように何かしらの定義をつける。
			while (stopFlagCount < 3);
				scoreAdd.stopFlag = false;
				scoreAdd.stopFlagBtn = true;
				stopFlagCount = 0;
				//次のオブジェクト
				iTween.MoveTo (preObj, iTween.Hash(
					"y", stopPositionY02,
					"time", 1f,
					"easeType", "easeInOutQuad"
				));

				//前のオブジェクト
				iTween.MoveTo (retObj, iTween.Hash(
					"y", stopPositionY01,
					"time",1f,
					"easeType", "easeInOutQuad"
				));

			// 3秒ごとに実行する
			yield return new WaitForSeconds(3f);
			}
	}
