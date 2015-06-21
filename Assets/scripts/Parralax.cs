using UnityEngine;
using System.Collections;

public class Parralax : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = Camera.main.transform.position * 0.5f;
		transform.position = Vector2.Lerp(transform.position, pos, 0.5f);
	}
}
