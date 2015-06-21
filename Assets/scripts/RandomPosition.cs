using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	public float width = 8;
	public float height = 8;

	// Use this for initialization
	void Start () {
		float x = Random.Range (0, width) - width / 2;
		float y = Random.Range (0, height) - height / 2;
		transform.position = new Vector2 (x,y);
	}
}
