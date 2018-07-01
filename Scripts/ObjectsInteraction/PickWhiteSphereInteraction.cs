using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWhiteSphereInteraction : PickSphereInteraction {

	public GameObject triggerGhost;
	public TriggerSoundPassage triggerSound;
	public GameMusicScript music;


	public override void OnClick ()
	{
		music.Stop ();
		triggerSound.PlayClipAndDestoryItSelf ();
		triggerGhost.SetActive (true);
		base.OnClick ();
	}
}
