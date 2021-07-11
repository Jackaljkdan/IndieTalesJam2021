using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JK.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class RandomClipsPlayer : MonoBehaviour
    {
        #region Inspector

        public List<AudioClip> clips = null;

        #endregion

        public AudioClip LastPlayedTrack { get; private set; }

        public AudioSource AudioSource => GetComponent<AudioSource>();

        public void PlayRandom()
        {
            try
            {
                int randomIndex = UnityEngine.Random.Range(0, clips.Count);
                AudioClip randomClip = clips[randomIndex];
                AudioSource.PlayOneShot(randomClip);
                LastPlayedTrack = randomClip;
            }
            catch (NullReferenceException)
            {
                // clips is null, ignore
            }
            catch (ArgumentOutOfRangeException)
            {
                // clips is empty, ignore
            }
        }
    }
    
    [Serializable]
    public class UnityEventRandomClipsPlayer : UnityEvent<RandomClipsPlayer> { }
}