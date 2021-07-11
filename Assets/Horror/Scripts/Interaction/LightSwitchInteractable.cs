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

        public LightTargetBehaviour lightTarget = null;

        public AudioClip audioClip = null;

        public UnityEvent onInteraction = new UnityEvent();

        #endregion

        protected override void PerformInteraction(RaycastHit hit)
        {
            if (lightTarget)
                lightTarget.Toggle();

            if (TryGetComponent(out AudioSource audioSource))
                audioSource.PlayOneShot(audioClip);

            onInteraction.Invoke();
        }
    }
}