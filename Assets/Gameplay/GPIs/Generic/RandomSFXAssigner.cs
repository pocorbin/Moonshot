using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFXAssigner : MonoBehaviour
{
    public List<AudioClip> m_possibleClips = new List<AudioClip>();

    public bool m_PlayOnStart = true;

    private bool isInitialized = false;

    private AudioSource mAudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
        AssignSFX();
    }

    private void Start()
    {
        if(m_PlayOnStart)
        {
            mAudioSource.Play();
        }
    }

    private void Initialize()
    {
        if(!isInitialized)
        {
            mAudioSource = GetComponent<AudioSource>();
            isInitialized = true;
        }
    }

    public void AssignSFX()
    {
        if(isInitialized && m_possibleClips.Count > 0)
        {
            int index = Random.Range(0, m_possibleClips.Count);
            mAudioSource.clip = m_possibleClips[index];
        }
    }
}
