using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public static float speed = 5.0f;
	public static float slideSpeed = 2.0f;

	public static Animator  animator;
	UIScript uiscript;

	// ゲームが始まった時に一回だけ呼ばれる
	void Start () {
		animator = GetComponent <Animator> ();
		uiscript = GameObject.Find ("PlayControllCanvas").GetComponent<UIScript> ();
        Debug.Log("OKfromPS");
    }

	void Update () {
		transform.position += Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * slideSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * slideSpeed * Time.deltaTime;
        }
	}

	// Triggerである障害物にぶつかったとき
	void OnTriggerEnter (Collider colider){

		var stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");
		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");
		bool isBarrier = colider.CompareTag ("barrier");
		bool isGoal = colider.CompareTag ("Goal");


		// 障害物に当たったとき
		if( (isHigh == true && isSlide == false) ||
			(isLow == true && isJump == false) ||
		    (isBarrier == true)){
            speed = 0;
			animator.SetBool ("DEAD", true);
            GameoverCanvasScript.GameoverCanvas.enabled = true;

        }

		//ゴールした時
		if(isGoal == true){
			speed = 0;
            Debug.Log("Goalをけんち");
			animator.SetBool ("WIN", true);
			// UI
			//Goal();
		}
	}
	public void Left(){
		transform.position += Vector3.left * slideSpeed * Time.deltaTime;
		transform.Rotate(0,-50 * Time.deltaTime,0);
	}

	public void Right(){
		transform.position += Vector3.right * slideSpeed * Time.deltaTime;
		transform.Rotate(0,50 * Time.deltaTime,0);
	}

	public void Jump(){
		animator.SetBool ("JUMP", true);
	}
}
