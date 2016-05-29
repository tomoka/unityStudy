// stop押した後の減速処理
using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	private GameObject retObj;
	private GameObject preObj;

	private float retObjY;
	private float preObjY;

	private int stopFlagCount = 0;

	// Use this for initialization
	void Start () {
		if(scoreAdd.stopFlag){
			StartCoroutine("objMoveY");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator objMoveY (){
		var first = true;

		while (first){
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
			//()の中に"true"を入れれば無限ループの指定。無限ループしない時は下記のように何かしらの定義をつける。
			if (stopFlagCount < 3){
				scoreAdd.stopFlag = false;
				scoreAdd.stopFlagBtn = true;
				stopFlagCount = 0;
				//次のオブジェクト
				iTween.MoveTo (preObj, iTween.Hash(
					"y", mainLoop.stopPositionY02,
					"time", 1f,
					"easeType", "easeInOutQuad"
				));

				//前のオブジェクト
				iTween.MoveTo (retObj, iTween.Hash(
					"y", mainLoop.
					stopPositionY01,
					"time",1f,
					"easeType", "easeInOutQuad"
				));

				first = false;

			}
		}

		// 3秒ごとに実行する
		yield return new WaitForSeconds(3f);
	}

}
