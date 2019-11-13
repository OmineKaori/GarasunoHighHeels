using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Recorder : MonoBehaviour {
	private float time=0.0f;
	private float[] timeNow;
	private int[] inkey;
	int i=0;
	public static float Maxtime=99f;




	// Use this for initialization
	void Start () {
		
		//Maxtime=PlayerPrefs.GetFloat("Maxtime");
	}
	
	// Update is called once per frame
	void Update () {

		/*現在進行形で行動を保存*/
		time = canvas2Script.timer;//常に時間は動くように

        //ボタンの種類と押した時の時間をそれぞれ保存
		if (Input.GetKey(KeyCode.RightArrow))
		{
			timeNow[i] = time;
			inkey[i] = 1;
			i++;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			timeNow[i] = time;
			inkey[i] = 0;
			i++;
		}
        /*
		if(Input.GetButtonDown("jumpbutton")){
			timeNow[i] = time;
			inkey[i] = 2;
			i++;
		}
        */
		/*ハイスコアだったら保存*/
/*		if (time <= Maxtime) {
			Debug.Log("最高スコア更新！");
			PlayerPrefsX.SetFloatArray ("timeX",timeNow);
			PlayerPrefsX.SetIntArray ("keyX",inkey);
			PlayerPrefs.SetFloat ("Maxtime",time);

			PlayerPrefs.Save();
	
		}*/

	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="goal"){
			if (time <= Maxtime) {
				Debug.Log("最高スコア更新！");
				PlayerPrefsX.SetFloatArray ("timeX",timeNow);
				PlayerPrefsX.SetIntArray ("keyX",inkey);
				PlayerPrefs.SetFloat ("Maxtime",time);

				PlayerPrefs.Save();

			}
		}
	}
						
}
