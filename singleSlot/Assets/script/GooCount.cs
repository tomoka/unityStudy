using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GooCount : MonoBehaviour {
	public static int gooCount;
	private string text;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		target = GetComponent<Text>();
		target.text = "Goo COUNT:" + gooCount.ToString();
	}
}
