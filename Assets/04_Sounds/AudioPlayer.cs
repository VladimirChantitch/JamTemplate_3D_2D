using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ResourcesManager;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    Coroutine coroutine = null;

    public event Action onSoundFinished;

    public void PlayAudioByName(string name)
    {
        soundDrawer clip = ResourcesManager.Instance.GetAudio(name);
        float length = 0;
        if (clip.disiredLenght <= 0)
        {
            length = clip.clip.length;
        }
        else
        {
            length = clip.disiredLenght;
        }

        audioSource.PlayOneShot(clip.clip);

        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(stopClip(length));
    }

    internal void Stop()
    {
        StopCoroutine(coroutine);
        audioSource.Stop();
        onSoundFinished = null;
    }

    IEnumerator stopClip(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Stop();
        onSoundFinished?.Invoke();
    }
}
