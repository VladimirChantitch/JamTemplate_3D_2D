/*   
    GameJam template for unity project
    Copyright (C) 2023  VladimirChantitch-MarmotteQuantique

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */


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
