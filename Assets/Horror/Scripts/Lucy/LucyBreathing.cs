using JK.Sounds;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Lucy
{
    public class LucyBreathing : MonoBehaviour
    {
        #region Inspector

        public float secondsBetweenBreaths = 2f;

        public RandomClipsPlayer breathingPlayer;

        public bool breathOnEnable = true;

        #endregion

        private void OnEnable()
        {
            if (breathOnEnable)
                PlayBreathingAndReschedule();
            else
                Invoke(nameof(PlayBreathingAndReschedule), secondsBetweenBreaths);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(PlayBreathingAndReschedule));
        }

        private void PlayBreathingAndReschedule()
        {
            breathingPlayer.PlayRandom();

            Invoke(nameof(PlayBreathingAndReschedule), breathingPlayer.LastPlayedTrack.length + secondsBetweenBreaths);
        }
    }
    
    [Serializable]
    public class UnityEventLucyBreathing : UnityEvent<LucyBreathing> { }
}