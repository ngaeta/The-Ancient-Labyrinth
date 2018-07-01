using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceVolume : MonoBehaviour {

	public AudioSource[] audioSources;
	public float [] newVolumeSources;

	public void VolumeDown() {
		int numberAudio = audioSources.Length;
		for(int i = 0; i < numberAudio; i++)
			audioSources[i].volume = newVolumeSources[i];
	}
}
