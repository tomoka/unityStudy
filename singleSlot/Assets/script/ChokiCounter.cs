using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChokiCounter : MonoBehaviour {
	public static int chokiCount;
	private string text;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		target = GetComponent<Text>();
		target.text = "CHOKI:" + chokiCount.ToString();
	}
}
