using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickYellowShereInteraction : PickSphereInteraction {

	public TempleScripting templeScripting;


	public override void OnClick() {
		templeScripting.CanActive = true;
		base.OnClick ();
	}


}
