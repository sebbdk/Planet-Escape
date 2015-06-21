using UnityEngine;
using System.Collections;

public class CreatureSpawner : MonoBehaviour {

	public GameObject[] creatures;
	public GameObject target;
	public int maxCreatures = 10;//not used
	public int initalSpawn = 2;
	public int difficulty = 1;//not used properly
	public int minDistance = 10;
	public int maxDistance = 15;
	public float spawnInterval = 10;
	public float spawnUntil = 0;

	public static bool allowSpawnage = true;

	private float lastSpawn;
	private GameObject[] spawnedCreatures;

	void Spawn() {
		if (target != null && creatures != null && allowSpawnage) {
			int spawnCount = initalSpawn * difficulty;

			for (int c = 0; c < spawnCount; c++) {
				int spawnIndex = Mathf.RoundToInt (Random.Range (0, creatures.Length));
				Vector3 position = RandomOnUnitCircle2 (Random.Range (minDistance, maxDistance));

				Instantiate (creatures [spawnIndex], (position + target.transform.position), target.transform.rotation);
				//GameObject creature = Instantiate (creatures [spawnIndex], (position + target.transform.position), target.transform.rotation) as GameObject;
				//GameObject tagHolder = new GameObject();
				//tagHolder.transform.SetParent(creature.transform);
				//tagHolder.tag = "Spawner_" + this.GetInstanceID().ToString();
			}
		}
	}

	public static Vector2 RandomOnUnitCircle2( float radius)  {
		Vector2 randomPointOnCircle = Random.insideUnitCircle;
		randomPointOnCircle.Normalize();
		randomPointOnCircle *= radius;
		return randomPointOnCircle;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawn > spawnInterval && (Time.time < spawnUntil || spawnUntil == 0)) {
			Spawn ();
			lastSpawn = Time.time;
		}
	}
}
