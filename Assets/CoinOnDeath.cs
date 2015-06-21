using UnityEngine;
using System.Collections;

public class CoinOnDeath : MonoBehaviour {

	public int count = 1;

	void OnDeath () {
		for (int c = 0; c < count; c++) {
			Vector3 pos = Random.insideUnitCircle;
			Instantiate (Resources.Load ("Coin"), transform.position + pos, transform.rotation);
		}
	}

}
