using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParCounter : MonoBehaviour {
	public static int parCount;
	private string text;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text target = null;
		target = GetComponent<Text>();
		target.text = "PAR:" + parCount.ToString();
	}
}
