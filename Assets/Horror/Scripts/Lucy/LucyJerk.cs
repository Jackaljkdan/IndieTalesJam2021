using JK.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Lucy
{
    [RequireComponent(typeof(Animator))]
    public class LucyJerk : MonoBehaviour
    {
        #region Inspector

        public float averageJerksPerSecond = 0.2f;

        #endregion

        private void Start()
        {
            JerkAndSchedule();
        }

        public void JerkAndSchedule()
        {
            Jerk();
            float waitSeconds = RandomUtils.Exponential(averageJerksPerSecond);
            Invoke(nameof(JerkAndSchedule), waitSeconds);
        }

        public void Unschedule()
        {
            CancelInvoke(nameof(JerkAndSchedule));
        }

        private void Jerk()
        {
            GetComponent<Animator>().Play("LucyHeadJerk", 1);
        }
    }
    
    [Serializable]
    public class UnityEventLucyJerk : UnityEvent<LucyJerk> { }
}