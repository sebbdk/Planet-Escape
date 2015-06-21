using UnityEngine;
using System.Collections;

public class ShySplosion : MonoBehaviour {

	public GameObject effect;
	public float splodeDistance = 0.55f;
	public float damageRadius = 2f;
	public float damage = 3f;
	private bool exploded;
	
	void Start () {
	
	}

	void Explode() {
		GameObject splosion = Instantiate(effect);
		splosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
		exploded = true;
		gameObject.SetActive(false);
		Destroy (gameObject);
		
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
		int i = 0;
		while (i < hitColliders.Length) {
			if(hitColliders[i].gameObject.activeSelf) {
				hitColliders[i].SendMessage("AddDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
			i++;
		}
	}
	
	void OnDeath() {
		Explode ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		if (player) {
			float distance = Vector2.Distance (player.transform.position, transform.position);
		
			if (distance < splodeDistance && !exploded) {
				Explode ();
			}
		}
	}
}
