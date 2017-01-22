using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJumpAudio : MonoBehaviour {

    [SerializeField]
    private AudioClip[] m_jumpSounds;
    private AudioSource m_audio;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        if (m_audio != null)
        {
            if (!m_audio.isPlaying)
            {
                int rand = Random.Range(0, m_jumpSounds.Length);

                m_audio.clip = m_jumpSounds[rand];
                m_audio.Play();
            }
        }
    }
}
