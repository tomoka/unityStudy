using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;
	//private float y = mainLoop.preObj.transform.position.y;
	//private enum positionY : float {4, 2, 5};
	public float positionY;
	public static int num = 0;


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
			//Score.score = num++;
			positionY = mainLoop.preObj.transform.position.y;

			if (positionY >= 2.5 && positionY < 4.5){
				num = (int)1;
			} else if (positionY >= 0.5 && positionY < 2.5 || positionY >= -3.5 && positionY < -1.5){
				num = (int)2;
			} else if (positionY >= 4.5 && positionY < 6.5 || positionY >= -1.5 && positionY < 0.5) {
				num = (int)3;
			} else if (positionY >= 6.5 || positionY < -3.5) {
				num = (int)1;
			}
			//num = (int)positionY;
			Score.score++;

			Debug.Log ("positionY----->" + positionY);
			Debug.Log ("num----->" + num);

			/*
			 * パー = (4.5~2.5)(-3.5~6.5)
			 * チョキ = (2.5~0.5)(-1.5~-3.5)
			 * グー = (6.5~4.5)(0.5~-1.5)
			 */

			switch ( num ){
				case 1:
					Debug.Log("パー");
					break;
				case 2:
					Debug.Log("チョキ");
					break;
				case 3:
					Debug.Log("ぐー");
					break;
				default:
					break;
				}
			mainLoop.result(num);
		
			} else {
				stopFlag = false;
			}

	}
}
