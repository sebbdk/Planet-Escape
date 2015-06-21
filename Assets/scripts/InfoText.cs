using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!CreatureSpawner.allowSpawnage) {
			GameObject[] creeps = GameObject.FindGameObjectsWithTag ("Creep");
			GetComponent<Text> ().text = creeps.Length + " OPPONENTS LEFT";
		} else {
			GetComponent<Text> ().text = "";
		}
	}
}
