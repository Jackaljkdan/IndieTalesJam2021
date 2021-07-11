using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Horror.Interaction
{
    public class SimpleLightTarget : LightTargetBehaviour
    {
        #region Inspector

        [SerializeField]
        private Light target = null;

        [SerializeField, FormerlySerializedAs("startsOff")]
        private bool _startsOff = false;

        #endregion

        public override Light Light => target;

        public override bool StartsOff => _startsOff;

        public override bool IsOn { get; protected set; }

        private float onIntensity;

        private void Start()
        {
            onIntensity = target.intensity;
            IsOn = true;

            if (StartsOff)
                Toggle();
        }

        public override void Toggle()
        {
            if (!enabled)
                return;

            if (IsOn)
                target.intensity = 0;
            else
                target.intensity = onIntensity;

            IsOn = !IsOn;
        }
    }
    
    [Serializable]
    public class UnityEventSimpleLightTarget : UnityEvent<SimpleLightTarget> { }
}