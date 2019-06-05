using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoulsCries : MonoBehaviour {

    public TriggerAudioSouls[] soulsAudio;
    public GameManager GameMng;

    public  AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        FinalDoorController.onDoorOpened += StartCries;
        FinalDoorController.onDoorClosing += StopCries;
    }

    void StartCries()
    {
        for (int i = 0; i < soulsAudio.Length; i++)
        {
            soulsAudio[i].UseUpdate = true;
        }
    }

    void StopCries()
    {
        if(GameMng.GetSoulsSaved < 3)
        {
            audioSource.Play();
            return;
        }

        for (int i = 0; i < soulsAudio.Length; i++)
        {
            if(soulsAudio[i] != null)
                soulsAudio[i].UseUpdate = false;
        }     
    }

    void OnDisable()
    {
        FinalDoorController.onDoorOpened -= StartCries;
        FinalDoorController.onDoorClosing -= StopCries;
    }
}
