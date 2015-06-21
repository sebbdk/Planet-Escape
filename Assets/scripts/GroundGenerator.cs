using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {

	public int size = 8;
	public GameObject tilePrefab;

	// Use this for initialization
	void Start () {
		generate ();
	}

	void generate() {
		float offset = (size / 2) - 0.5f;
		for (int xPos = 0; xPos < size; xPos++) {
			for (int yPos = 0; yPos < size; yPos++) {
				GameObject newTile = Instantiate(tilePrefab);
				newTile.transform.position = new Vector2(xPos-offset, yPos-offset);
			}
		}

		transform.position = new Vector3 (0, 0, -size);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
