using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class FirstKeySequence1 : StayTriggerAction
    {
        #region Inspector

        public GameObject nextSequence;

        public List<LightTargetBehaviour> lightsToTurnOff;

        #endregion

        [Inject(Id = "player.camera")]
        private Transform playerCamera = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject]
        private FirstKeySequence3 finalSequence = null;

        private void Awake()
        {
            lucy.gameObject.SetActive(false);
            finalSequence.onFinished.AddListener(OnFinished);
        }

        protected override bool CanPerformAction()
        {
            float dot = Vector3.Dot((lucy.position - playerCamera.position).normalized, playerCamera.forward);

            return dot <= 0.35f;
        }

        protected override void PerformTriggeredAction()
        {
            foreach (var light in lightsToTurnOff)
                if (light != null && light.IsOn)
                    light.Toggle();

            lucy.gameObject.SetActive(true);
            nextSequence.SetActive(true);
        }

        private void OnFinished()
        {
            if (finalSequence != null)
                finalSequence.onFinished.RemoveListener(OnFinished);

            foreach (var light in lightsToTurnOff)
                if (light != null && !light.IsOn)
                    light.Toggle();

            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventFirstKeySequence1 : UnityEvent<FirstKeySequence1> { }
}