using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public static int score;
	private string text;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		target = GetComponent<Text>();
		target.text = "AAAAAAA";
		target.text = "SCORE:" + score.ToString();
	
	}
}
