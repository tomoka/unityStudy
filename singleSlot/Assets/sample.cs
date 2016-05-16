using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sample : MonoBehaviour {
	RectTransform rectTransform = null;
	//Transform Transform = null;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("rectTransform.localPosition--->" + (this.rectTransform.localPosition));
		Debug.Log("rectTransform.rect--->" + (this.rectTransform.rect));
		Debug.Log("rectTransform.position--->" + (this.rectTransform.position));

	}
}
