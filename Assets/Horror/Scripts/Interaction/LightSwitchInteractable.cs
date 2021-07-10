using JK.Interaction;
using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Interaction
{
    public class LightSwitchInteractable : InteractableBehaviour
    {
        #region Inspector

        [SerializeField]
        private LightTargetBehaviour lightTarget = null;

        [SerializeField]
        private AudioClip audioClip = null;

        public UnityEvent onInteraction = new UnityEvent();

        #endregion

        protected override void PerformInteraction(RaycastHit hit)
        {
            if (lightTarget)
                lightTarget.Toggle();

            var source = gameObject.GetOrAddComponent<AudioSource>();
            source.spatialBlend = 1;
            source.PlayOneShot(audioClip);

            onInteraction.Invoke();
        }
    }
}