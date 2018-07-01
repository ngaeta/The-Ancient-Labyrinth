using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour {

	public AudioMixer audio;
	public string sfxExposedParameter = "effectsVol";
	public string musicExposedParameter = "musicVol";

	public void ChangeSfxVol(float newVol) {
		audio.SetFloat (sfxExposedParameter, newVol);
	}

	public void ChangeMusicVol(float newVol) {
		audio.SetFloat (musicExposedParameter, newVol);
	}
}
