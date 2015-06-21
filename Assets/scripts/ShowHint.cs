using UnityEngine;
using System.Collections;

public class ShowHint : MonoBehaviour {

	public GameObject hint;

	void Start() {
		hint.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player" && !gameObject.GetComponentInParent<ActivateBossEvent>().activated) {
			hint.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Player") {
			hint.SetActive (false);
		}
	}
}
