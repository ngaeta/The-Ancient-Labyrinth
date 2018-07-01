using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAnkhZombieInteraction : PickObjectInteraction {


	public ZombieMummyController zombie;
	public TriggerVoiceZombieMummy triggerZombie;

	public override void OnClick ()
	{
		base.OnClick ();
		zombie.Attack ();
		triggerZombie.CanDestroyMonster ();
	}
}
