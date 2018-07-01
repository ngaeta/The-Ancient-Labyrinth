using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRedSphereInteraction : PickSphereInteraction {

	public GameMusicScript music;

	public override void OnClick ()
	{
		music.Stop ();
		base.OnClick ();
	}
}
