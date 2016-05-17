using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;
	//private float y = mainLoop.preObj.transform.position.y;
	//private enum positionY : float {4, 2, 5};
	public float positionY;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ButtonPush() { // MUST public
		//Debug.Log ("clicked");
		if (!stopFlag) {
			stopFlag = true;
			//int num = (int)Screen.dpi;
			int num;
			//Score.score = num++;
			positionY = mainLoop.preObj.transform.position.y;
			num = (int)positionY;
			Score.score = num;

			Debug.Log ("num----->" + num);


			/*3=パー(2.6)
			 * 1.8=チョキ()
			 * 5.4 = グー
			 */
			switch ( num ){
				case 3:
					Debug.Log("パー");
					break;
				case 5:
					Debug.Log("ぐー");
					break;
				case 1:
					Debug.Log("チョキ");
					break;
				default:
					break;
				}
		
			} else {
				stopFlag = false;
			}

	}
}
