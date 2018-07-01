using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMummySarcophaguesController : MonoBehaviour {

	public MummySarcophagusController[] mummies;
	public bool PlayScream = true;

	public float[] rateMummiesMovement;
	public float timeAfterAllMummyMovement = 1.5f;
	public int[] mummySymultanely;

	private int lastMummies = -1;
	public int maxAllMummiesSimultanely = 1;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			if (maxAllMummiesSimultanely > 0) {
				maxAllMummiesSimultanely--;
				MoveAllMummy ();
			}
			Invoke ("MoveMummies", timeAfterAllMummyMovement);
		}
	}

	private void MoveMummies() {
		int mummy;
		int number = 0;
		int mummiesSimultanely = Random.Range (0, mummySymultanely.Length);
		while (number < mummiesSimultanely) {
			mummy = Random.Range (0, mummies.Length);
			if (mummy == lastMummies)
				continue;
			else {
				mummies [mummy].PlayAnimationMoving ();
				if(PlayScream)
					mummies [mummy].PlayScream ();
				number++;
				lastMummies = mummy;
			}
		}

		float timeNext = Random.Range (0, rateMummiesMovement.Length);
		Invoke ("MoveMummies", timeNext);
	}

	private void MoveAllMummy() {
		foreach (MummySarcophagusController m in mummies)
			m.PlayAnimationMoving ();
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.CompareTag ("Player"))
			CancelInvoke ();
	}
}
