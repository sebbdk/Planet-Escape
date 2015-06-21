using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	GameObject player;
	float spawnTime;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - spawnTime > 2) {
			Rigidbody2D body = GetComponent<Rigidbody2D> ();
			Vector2 dir = player.transform.position - transform.position;
			body.AddForce (dir * 20);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			//AudioSource.PlayClipAtPoint(sound, transform.position);
			Destroy(gameObject);
		}
	}
}
