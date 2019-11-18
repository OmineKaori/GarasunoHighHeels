using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas2Script : MonoBehaviour {
	
	Canvas canvas2;
	public Text TimeText;
	public static float timer;

	void Start(){
		timer = 0.0f;
		canvas2 = GetComponent<Canvas> ();

		canvas2.enabled = true;

		TimeText.text = "time";

	}

	void Update(){
		timer += Time.deltaTime;
		TimeText.text = timer.ToString ("f1");	
	}


}

