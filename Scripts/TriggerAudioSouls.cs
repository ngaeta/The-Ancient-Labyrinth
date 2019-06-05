using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioSouls : MonoBehaviour
{
    private AudioSource m_AudioSource;

    public AudioClip[] clipSouls;
    public float[] rangeBetweenAudio;
    public float MinAudioDistance = 5f;
    public float MaxAudioDistance = 100f;

    public bool UseUpdate
    {
        set
        {
            useUpdate = value;
            if (value)
            {
                m_AudioSource.volume = 1f;
                m_AudioSource.spatialBlend = 0f;
            }
        }
    }

    private int m_NextClip;
    private bool m_CanNext;
    private bool useUpdate;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_NextClip = 0;
        m_CanNext = true;
    }

    void Update()
    {
        if (useUpdate)
        {
            PlayClip();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player") && !useUpdate)
        {
            PlayClip();
        }
    }

    private void PlayClip()
    {
        if (m_CanNext)
        {
            m_CanNext = false;
            m_AudioSource.clip = clipSouls[m_NextClip];
            m_AudioSource.Play();
            m_NextClip = (m_NextClip + 1) % clipSouls.Length;
            StartCoroutine(WaitToNextClip());
        }
    }

    private IEnumerator WaitToNextClip()
    {
        int nextTime = Random.Range(0, rangeBetweenAudio.Length);
        yield return new WaitForSeconds(m_AudioSource.clip.length + rangeBetweenAudio[nextTime]);
        m_CanNext = true;
    }
}
