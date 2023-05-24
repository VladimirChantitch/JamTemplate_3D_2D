using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private float m_MainAudioVolume;

        [HideInInspector] public float MainAudioVolume
        {
            get { return m_MainAudioVolume; }
            set { 
                if (value > 100)
                {
                    m_MainAudioVolume = 100;
                }
                else
                {
                    m_MainAudioVolume = value;
                }
            }
        }
    }
}

