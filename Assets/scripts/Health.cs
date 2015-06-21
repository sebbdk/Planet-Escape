using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth = 10;
	public float current = 10;
	public bool dead;

	// Update is called once per frame
	void AddDamage (float damage) {
		current -= damage;

		if(current <= 0) {
			dead = true;
			gameObject.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(false);
		}
	}
}
