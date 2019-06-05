using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSnakeSceptreInteraction : PickObjectInteraction {

	public SnakeController snakeController;

	public override void OnClick ()
	{
		snakeController.Attack ();
		base.OnClick ();
	}
}
