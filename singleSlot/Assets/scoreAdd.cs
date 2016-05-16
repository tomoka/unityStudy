using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;
	//private float y = mainLoop.preObj.transform.position.y;
	//private enum positionY : float {4, 2, 5};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ButtonPush() { // MUST public
		Debug.Log ("clicked");
		if (!stopFlag) {
			stopFlag = true;
			int num = (int)Screen.dpi;
			Score.score = num;

			//positionY = y;

			/*switch ( !positionY ){
				case 2:
					Debug.Log(y);
					Debug.Log("パー");
					break;
				case 4:
					Debug.Log(y);
					Debug.Log("ぐー");
					break;
				case 5:
					Debug.Log(y);
					Debug.Log("チョキ");
					break;
				default:
					break;
				}*/
			} else {
				stopFlag = false;
			}

	}
}
