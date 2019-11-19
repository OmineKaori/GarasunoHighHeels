using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {
	int i;
	private float[] Ghosttime;
	private int[] Ghostkey;
	private float time=0.0f;


	// Use this for initialization

	void Start () {
        i = 0;
		Ghosttime = PlayerPrefsX.GetFloatArray("timeX");
		Ghostkey = PlayerPrefsX.GetIntArray ("keyX");

        Debug.Log("OK");
        Debug.Log(Ghosttime);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * PlayerScript.speed * Time.deltaTime;

        time += Time.deltaTime;  //常に時間は動くように

        if (Ghosttime.Length != 0)
        {
            Debug.Log("ゴースト起動中");
            if (time >= Ghosttime[i])
            {
                if (Ghostkey[i] == -1)
                {
                    transform.position += Vector3.left * PlayerScript.slideSpeed * Time.deltaTime;
                }

                if (Ghostkey[i] == 1)
                {
                    transform.position += Vector3.right * PlayerScript.slideSpeed * Time.deltaTime;
                }

                if (Ghostkey[i] == 0)
                {

                }

                //if (Ghostkey[i] == 2)
                //{
                //    Jump();
                //}
                i += 1;
            }
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("初めてのプレイヤーだよ！");
        }

	}

	public void Left(){
		transform.position += Vector3.left * PlayerScript.slideSpeed * Time.deltaTime;
		transform.Rotate(0,-50 * Time.deltaTime,0);
	}

	public void Right(){
		transform.position += Vector3.right * PlayerScript.slideSpeed * Time.deltaTime;
		transform.Rotate(0,50 * Time.deltaTime,0);
	}

	public void Jump(){
		PlayerScript.animator.SetBool ("JUMP", true);
	}
}
