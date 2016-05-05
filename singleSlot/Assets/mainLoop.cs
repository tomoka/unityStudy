using UnityEngine;
using System.Collections;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;

	void Start () {

		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			//objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}

		//GameObject emptyObj = new GameObject("emptyObj");
		//GameObject prefab = new GameObject("emptyObj");
		//prefab = (GameObject)Resources.Load("Assets/slotImgPrefab");
		//Instantiate(prefab);
		//GameObject prefab2 = (GameObject)Instantiate(prefab);
		//emptyObj = (GameObject)Instantiate(prefab);
		//prefab.transform.name = "aaaaaaaaaaaaa";
		//Debug.Log("emptyObjemptyObj------>" + prefab.transform.name);
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject prefab = new GameObject("emptyObj");
		//prefab = (GameObject)Resources.Load("slotPrefab");
		//GameObject instance = Instantiate(Resources.Load("slotPrefab")) as GameObject;

		GameObject retObj = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
		retObj.transform.name = "aaaaaaaaaaaaa";
		retObj.transform.parent = gameObject.transform;
	}
}
