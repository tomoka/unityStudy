using UnityEngine;
using System.Collections;

public class mainLoop : MonoBehaviour {
	// Use this for initialization
	public GameObject objB;
	public GameObject prefab;
	public HingeJoint[] hingeJoints;

	void Start () {
		if (gameObject.transform.IsChildOf(gameObject.transform)){
			Debug.Log("true");
			Debug.Log(gameObject.transform.name);
			//objB.SendMessage("test");
		}else{
			Debug.Log("false");
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject retObj = Instantiate(Resources.Load("slotPrefab", typeof(GameObject))) as GameObject;
		retObj.transform.name = "aaaaaaaaaaaaa";
		retObj.transform.position = new Vector3(0,8,10);
		retObj.transform.parent = gameObject.transform;

		var sr = retObj.GetComponent<SpriteRenderer>();
		var width = sr.bounds.size.x;
		var height = sr.bounds.size.y;

		Debug.Log("sr.bounds.size.x--->" + (width * 192));
		Debug.Log("sr.bounds.size.y--->" + (height * 192));
		Debug.Log("position--->" + retObj.transform.position);
		Debug.Log("right---->" + retObj.transform.right);
		Debug.Log("localScale---->" + retObj.transform.localScale);
	}

	void example() {
	}
}
