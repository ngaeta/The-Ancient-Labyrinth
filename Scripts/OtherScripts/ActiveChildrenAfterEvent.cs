﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChildrenAfterEvent : MonoBehaviour {

	public float secondToActiveBats = 4f;
	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource> ();
		DoorCaveController.OnDoorOpenedEvent += ActiveBatsChildren;
	}

	private void ActiveBatsChildren() {
		m_AudioSource.Play ();
		StartCoroutine (WaitToActiveBats ());
	}

	private IEnumerator WaitToActiveBats () {
		yield return new WaitForSecondsRealtime (secondToActiveBats);
		m_AudioSource.Stop ();
		int children = transform.childCount;
		for (int i = 0; i < children; i++)
			transform.GetChild (i).gameObject.SetActive (true);
		Destroy (gameObject, 20f);
	}

}
