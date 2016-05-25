using UnityEngine;
using System.Collections;

public class singleSpawn : MonoBehaviour {
	public GameObject prefab;
	public float intervalSecond = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine("Spawn");
		test();
	
	}
	
	IEnumerator Spawn() {
		while(true) {
			//float differenceY = (Random.value - 0.5f) * randomOffsetY;
			//Vector3 difference = new Vector3(0, differenceY, 0);
			//Instantiate(prefab, this.transform.position + difference, prefab.transform.rotation);
			//GameObject retObj = (GameObject)Resources.Load ("slotImg");
			//Instantiate(prefab);
			//Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
			//retObj.transform.parent = gameObject.transform;
			//retObj.transform.parent = gameObject.transform.parent.parent;
			//retObj.transform.parent = gameObject.transform.parent;

			//Debug.Log(gameObject.transform.parent.name);
			//Debug.Log(retObj.transform.parent);

			//retObj.transform.name = "aaaaaaaaaaaaa";
			//Debug.Log(retObj.transform.name);
			//this.transform.parent = gameObject.transform;
			yield return new WaitForSeconds(intervalSecond);
		}
	}
	void test(){
		//Debug.Log("testttt()");	
		//Debug.Log(this.transform.name);	
	}

}
