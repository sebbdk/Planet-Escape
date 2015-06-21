using UnityEngine;
using System.Collections;

public class NPCHealthBar : MonoBehaviour {

	public GameObject bar;


	void Update () {
		Set ();
	}

	void Set() {
		Health health = gameObject.GetComponentInParent<Health> ();
		if (health != null && health.current != health.maxHealth) {
			bar.transform.localScale = new Vector2 (health.current / health.maxHealth, 1);

			Renderer render = GetComponent<Renderer> ();
			render.enabled = true;
			render = bar.GetComponent<Renderer> ();
			render.enabled = true;
		} else {
			Renderer render = GetComponent<Renderer> ();
			render.enabled = false;
			render = bar.GetComponent<Renderer> ();
			render.enabled = false;
		}
	}
}
