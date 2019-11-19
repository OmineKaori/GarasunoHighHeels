using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Recorder : MonoBehaviour {
    public static float Maxtime = 99f;
    private float time = 0.0f;
	private float[] timeNow = new float[100];
	private int[] inkey = new int[100];
	int i=0;



	// Use this for initialization
	void Start () {
		
		Maxtime=PlayerPrefs.GetFloat("Maxtime");
        Debug.Log("OKfromRE");

    }
	
	// Update is called once per frame
	void Update () {

		/*現在進行形で行動を保存*/
		time = canvas2Script.timer;//常に時間は動くように

        //ボタンの種類と押した時の時間をそれぞれ保存
        //右が押されたら1,左が押されたら-1,キーが離されたら0
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			timeNow[i] = time;
			inkey[i] = 1;
			i++;
		}
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            timeNow[i] = time;
            inkey[i] = 0;
            i++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			timeNow[i] = time;
			inkey[i] = -1;
			i++;
		}
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
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
        PlayerPrefsX.SetFloatArray("timeX", timeNow);
        PlayerPrefsX.SetIntArray("keyX", inkey);

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
