using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float followDistanceMax = 5f;
	public float followDistanceMin = 0.5f;
	public float speed = 0.6f;

	void Start () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		body.transform.position = new Vector3 (body.transform.position.x, body.transform.position.y, body.transform.position.y);
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		if (player) {
			float distance = Vector2.Distance (player.transform.position, transform.position);

			if (distance < followDistanceMax && distance > followDistanceMin) {
				Vector2 dir = player.transform.position - transform.position;
				body.velocity = dir.normalized * speed;

				if (body.velocity.x > 0) {
					gameObject.transform.localScale = new Vector2(-1, 1);
				} else if (body.velocity.x < 0) {
					gameObject.transform.localScale = new Vector2(1, 1);
				}

				body.transform.position = new Vector3 (body.transform.position.x, body.transform.position.y, body.transform.position.y);
			} else {
				body.velocity = new Vector2 ();
			}
		}
	}
}
