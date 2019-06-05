using UnityEngine;
using System.Collections;

public interface Monster {

	void AlertMonster (Transform target);
	void WalkMonster ();
	void IdleMonster();
	void RunMonster();
	void SearchPlayerMonster();
}
