using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLittleStones : MonoBehaviour {

	public GameObject stonesToSpawn;
	public float timeToDestroy = 2.5f;
	public Vector3 scale = new Vector3(10f, 10f, 10f);

	public bool debugstones = false;

	void Start() {
		if(debugstones)
			InvokeRepeating ("SpawnStones", 3, 10f);
	}

	public void SpawnStones() {
		GameObject stones = Instantiate (stonesToSpawn, transform.position, Quaternion.identity);
		stones.transform.localScale = scale;
		Destroy (stones, timeToDestroy);
	}
}
