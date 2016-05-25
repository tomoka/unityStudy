using UnityEngine;
using System.Collections;

public class scoreAdd : MonoBehaviour {
	public static bool stopFlag = false;
	//private float y = mainLoop.preObj.transform.position.y;
	//private enum positionY : float {4, 2, 5};
	public float positionY;
	public float positionY01;
	public float positionY02;
	public static int num = 0;
	public static bool stopFlagBtn = true;


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

			//上の画像の位置で表示内容を判定
			positionY = mainLoop.preObj.transform.position.y;

			/*
			 * パー = (4.5~2.5)(-3.5~6.5)|(1.6~3.14)
			 * チョキ = (2.5~0.5)(-1.5~-3.5)|(-0.25~1.56)(6.5~8.0)
			 * グー = (6.5~4.5)(0.5~-1.5)|(3.14~5.14)
			 */

			//上のパー
			if (positionY >= 1.6 && positionY < 3.35) {
				num = (int)1;
				Debug.Log("パー");

				positionY01 = -2.88f;
				positionY02 = 2.53f;
			}
			//下のチョキ
			else if (positionY >= 5.29 && positionY < 7.13) {
				num = (int)2;
				Debug.Log("チョキ");

				positionY01 = 0.72f;
				positionY02 = 6.13f;
			}
			//上のグー
			else if (positionY >= 3.35 && positionY < 5.29) {
				num = (int)3;
				Debug.Log("ぐー");

				positionY01 = -1.11f;
				positionY02 = 4.3f;
			}
			//下のパー（この表示だけありうる）
			else if (positionY >= 7.13) {
				num = (int)1;
				Debug.Log("パー");

				positionY01 = 2.53f;
				positionY02 = 7.94f;
			}

			Score.score++;
			switch(num){
				case 1:
					ParCounter.parCount++;
					break;
				case 2:
					ChokiCounter.chokiCount++;
					break;
				case 3:
					GooCounter.gooCount++;
					break;
				}

			Debug.Log ("positionY----->" + positionY);
			Debug.Log ("num----->" + num);

			mainLoop.result(num,positionY01,positionY02);
		
			} else {
				//elseの処理なしにする。mainLoopに処理を寄せる
				//stopFlag = false;
			}

	}
}
