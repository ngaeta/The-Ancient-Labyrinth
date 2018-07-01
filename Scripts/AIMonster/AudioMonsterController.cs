using UnityEngine;
using System.Collections;

public class AudioMonsterController : MonoBehaviour {

	public AudioWalkMonster AudioFootDx;
	public AudioWalkMonster AudioFootSx;
	public AudioVoiceMonster AudioVoice;

	private int m_IndexFoot = 0;

	public void PlayAudioWalk() {
		if (m_IndexFoot == 0)
			AudioFootDx.Play ();
		else
			AudioFootSx.Play ();
		m_IndexFoot = (m_IndexFoot + 1) % 2;
	}

	public void PlayAudioVoice() {
		AudioVoice.Play ();
	}
}
