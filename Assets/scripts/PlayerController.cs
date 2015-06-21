using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject bulletPrefab;
	private float lastShot;
	public float shootCD = 0.2f;
	public GameObject replayBtn;
	public Animator anim;

	private GameObject gun;

	// Use this for initialization
	void Start () {
		gun = GameObject.Find ("gun");
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		handleWalking ();
		handleShooting ();

		GameObject[] creeps = GameObject.FindGameObjectsWithTag ("Creep");

		if(ActivateBossEvent.deactivateCount >= 3) {
			CreatureSpawner.allowSpawnage = false;
		}

		if (ActivateBossEvent.deactivateCount >= 3 && creeps.Length == 0) {
			win ();
		}
	}

	public void reload() {
		Application.LoadLevel(Application.loadedLevel);
	}

	void win() {
		CreatureSpawner.allowSpawnage = true;
		ActivateBossEvent.deactivateCount = 0;
		Message.text("YOU WIN!!!");
		replayBtn.SetActive(true);
		Time.timeScale = 0;
	}

	void OnDeath() {
		CreatureSpawner.allowSpawnage = true;
		ActivateBossEvent.deactivateCount = 0;
		Message.text("GAME OVER");
		replayBtn.SetActive(true);
		Time.timeScale = 0;
	}

	void handleShooting() {
		Vector2 dir = new Vector2 ();
		if (Input.GetKey ("up")) {
			dir.y += 1;
		}
		if (Input.GetKey ("down")) {
			dir.y -= 1;
		}
		if (Input.GetKey ("left")) {
			dir.x -= 1;
		}
		if (Input.GetKey ("right")) {
			dir.x += 1;
		}

		if (dir.x != 0) {
			gameObject.transform.localScale = new Vector2(-dir.x, 1);
		}

		if (dir.magnitude > 0 && Time.time > lastShot + shootCD) {
			GameObject bullet = Instantiate (bulletPrefab);
			Rigidbody2D body = bullet.GetComponent<Rigidbody2D> ();

			dir.x += Random.Range(-0.1f, 0.1f);
			dir.y += Random.Range(-0.1f, 0.1f);
			bullet.transform.position = new Vector3 (gun.transform.position.x, gun.transform.position.y, -gun.transform.position.y);

			body.velocity = dir * 6;
			lastShot = Time.time;

			PixelFix.screenShake();
		}
	}

	void handleWalking() {
		Vector2 dir = new Vector2 ();
		if (Input.GetKey ("w")) {
			dir.y += 1;
		}
		if (Input.GetKey ("s")) {
			dir.y -= 1;
		}
		if (Input.GetKey ("a")) {
			dir.x -= 1;
		}
		if (Input.GetKey ("d")) {
			dir.x += 1;
		}

		if (dir.magnitude > 0) {
			anim.SetBool ("walking", true);
		} else {
			anim.SetBool ("walking", false);
		}

		if (dir.x != 0) {
			gameObject.transform.localScale = new Vector2(-dir.x, 1);
		}
		
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		body.velocity = dir * 2;
		body.transform.position = new Vector3 (body.transform.position.x, body.transform.position.y, body.transform.position.y-0.4f);
	}
}
