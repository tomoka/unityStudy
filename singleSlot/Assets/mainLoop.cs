using UnityEngine;
using System.Collections;
using System;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;
	public int count;
	private float timerNow;
	private float timerPass;
	private float waitTime;
	private float datetimeStr;

	void Start () {
		count = 0;
		waitTime = 5f;
		datetimeStr = System.DateTime.Now;

		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			//objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}
	}
	
	// Update is called once per frame
	void Update (){
		timerNow = System.DateTime.Now;
		timerPass = timerNow - datetimeStr;
		//timer += Time.deltaTime;
		Debug.Log("timerPass--->" + timerPass);
		if (timerPass > waitTime) {
			//do something.
			Invoke("example", 1);
			datetimeStr = System.DateTime.Now;
		}
		//Score.score++;
	}

	void example() {
		if(!scoreAdd.stopFlag){
			GameObject retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
			retObj.transform.name = "Obj" + (count++);
			retObj.transform.position = new Vector3(2,5,10);
			retObj.transform.parent = gameObject.transform;

			var sr = retObj.GetComponent<SpriteRenderer>();
			var width = sr.bounds.size.x;
			var height = sr.bounds.size.y;

			Debug.Log("sr.bounds.size.x--->" + (width));
			Debug.Log("sr.bounds.size.y--->" + (height));
			Debug.Log("position--->" + retObj.transform.position);
			Debug.Log("right---->" + retObj.transform.right);
			Debug.Log("localScale---->" + retObj.transform.localScale);
		}
	}
}
