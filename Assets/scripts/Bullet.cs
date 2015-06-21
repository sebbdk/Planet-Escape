using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject impact;
	public GameObject flash;

	public string targetTag = "Creep";
	public float damage = 3f;
	public float lifeTime = 4f;
	public float spawnTime = 1;

	void Start () {
		spawnTime = Time.time;

		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		body.transform.position = new Vector3 (body.transform.position.x, body.transform.position.y, body.transform.position.y);

		Instantiate(flash, transform.position, transform.rotation);
	}

	void Update () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		body.transform.position = new Vector3 (body.transform.position.x, body.transform.position.y, body.transform.position.y);

		if (Time.time > spawnTime + lifeTime) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == targetTag) {
			collider.SendMessage("AddDamage", damage);
			gameObject.SetActive(false);
			Destroy(gameObject);
		} 

		if(collider.tag != "Player") {
			Instantiate(impact, transform.position, transform.rotation);
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

}
