using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSphereInteraction : PickObjectInteraction{

	public GameManager gameManager;
	public enum ColorSphere {BLUE, MAGENTA, YELLOW, ORANGE, RED, GREEN, WHITE, BLACK};
	[SerializeField] private ColorSphere color;

	public override void OnClick ()
	{		
		gameManager.SpherePicked();
		base.OnClick ();
	}

	public ColorSphere GetColorSphere {
		get {
			return color;
		}
	}
}
