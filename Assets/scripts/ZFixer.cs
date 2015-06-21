using UnityEngine;
using System.Collections;

public class ZFixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);
		Physics2D.IgnoreLayerCollision (8, 9);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);
	}
}
