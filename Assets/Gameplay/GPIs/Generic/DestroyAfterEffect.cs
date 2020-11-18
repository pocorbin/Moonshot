using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyAfterEffect : MonoBehaviour
{
    ParticleSystem mParticleSystem;
    AudioSource mAudioSource;
    bool hasPlayedVisualEffectOnce = false;
    bool visualEffectIsFinished = false;
    bool hasPlayedSoundEffectOnce = false;
    bool soundEffectIsFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        mParticleSystem = GetComponent<ParticleSystem>();
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mParticleSystem != null)
        {
            CheckVisualEffectStatus();
        } else
        {
            hasPlayedVisualEffectOnce = true;
        }
        if(mAudioSource != null)
        {
            CheckSoundEffectStatus();
        } else
        {
            hasPlayedSoundEffectOnce = true;
        }
        CheckDestroy();
    }

    private void CheckVisualEffectStatus()
    {
        if (!hasPlayedVisualEffectOnce && mParticleSystem.isPlaying)
        {
            hasPlayedVisualEffectOnce = true;
        }
        if (hasPlayedVisualEffectOnce && !mParticleSystem.isPlaying)
        {
            visualEffectIsFinished = true;
        }
    }

    private void CheckSoundEffectStatus()
    {
        if(!hasPlayedSoundEffectOnce && mAudioSource.isPlaying)
        {
            hasPlayedSoundEffectOnce = true;
        }
        if (hasPlayedSoundEffectOnce && !mAudioSource.isPlaying)
        {
            soundEffectIsFinished = true;
        }
    }

    private void CheckDestroy()
    {
        if(visualEffectIsFinished && soundEffectIsFinished)
        {
            Destroy(this.gameObject);
        }
    }
}
