using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			Health playerHP = player.GetComponent<Health> ();
			float health = playerHP.current / playerHP.maxHealth;
			transform.localScale = new Vector2 (health, 1);
		}
	}
	
}
