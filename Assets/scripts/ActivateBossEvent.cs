using UnityEngine;
using System.Collections;

public class ActivateBossEvent : MonoBehaviour {

	public GameObject[] creatures;
	public GameObject flare;
	public GameObject effect;
	public bool activated;
	public bool canActivate;

	private float deactivateTime;
	private float duration = 20;

	public static int deactivateCount;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			canActivate = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Player") {
			canActivate = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space") && !activated && canActivate) {
			activated = true;

			gameObject.AddComponent<CreatureSpawner>();
			CreatureSpawner spawner = gameObject.GetComponent<CreatureSpawner>();
			spawner.spawnInterval = 1.5f;
			spawner.minDistance = 5;
			spawner.maxDistance = 7;
			spawner.spawnUntil = Time.time + duration;
			spawner.creatures = creatures;
			spawner.target = gameObject;

			deactivateTime = Time.time + duration;

			flare = Instantiate(flare, transform.position+new Vector3(0, -0.3f, 0), transform.rotation) as GameObject;

			Message.text("CLEAR THE AREA!");
		}

		if (activated && Time.time > deactivateTime) {
			deactivateCount++;
			Explode();
		}
	}

	void Explode() {
		GameObject splosion = Instantiate(effect) as GameObject;
		splosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
		gameObject.SetActive(false);
		flare.SetActive (false);
		
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2);
		int i = 0;
		while (i < hitColliders.Length) {
			if(hitColliders[i].gameObject.activeSelf) {
				hitColliders[i].SendMessage("AddDamage", 3, SendMessageOptions.DontRequireReceiver);
			}
			i++;
		}

		for (int c = 0; c < 5; c++) {
			Vector3 pos = Random.insideUnitCircle;
			Instantiate (Resources.Load ("Coin"), transform.position + pos, transform.rotation);
		}
	}
}
