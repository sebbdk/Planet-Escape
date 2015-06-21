using UnityEngine;
using System.Collections;

public class PixelFix : MonoBehaviour {

	public static GameObject cam; // set this via inspector
	public static float shake = 0f;
	public static float shakeAmount = 0.1f;
	public static float decreaseFactor = 1.0f;

	// Use this for initialization
	void Start () {
		//s_baseOrthographicSize = Screen.height / 32.0f / 2.0f;
		Camera.main.orthographicSize = Screen.height / 32.0f / 4.0f;
		cam = this.gameObject;
	}

	public static void screenShake() {
		shake = 0.1f;
	}

	void Update() {
		if (shake > 0) {
			cam.transform.localPosition = Random.insideUnitSphere * shakeAmount + cam.transform.position;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0.0f;
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if(player) {
			Vector3 pos = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
			pos.z = -50;
			transform.position = pos;
		}
	}

}
