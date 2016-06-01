using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;
	public static bool stopFlagBtn = true;

	//private float y = mainLoop.preObj.transform.position.y;
	//private enum positionY : float {4, 2, 5};
	public float positionY;
	public float positionY01;
	public float positionY02;
	public static int num = 0;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ButtonPush() { // MUST public

		if (!stopFlag && stopFlagBtn) {
			stopFlag = true;
			stopFlagBtn = false;
			} else {
			stopFlag = false;
			stopFlagBtn = true;

			Debug.Log("ボタンフラグ");
			}

	}
}
