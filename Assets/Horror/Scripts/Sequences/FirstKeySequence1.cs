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

        #endregion

        [Inject(Id = "player.camera")]
        private Transform playerCamera = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        private void Awake()
        {
            lucy.gameObject.SetActive(false);
        }

        protected override bool CanPerformAction()
        {
            float dot = Vector3.Dot((lucy.position - playerCamera.position).normalized, playerCamera.forward);

            return dot <= 0.35f;
        }

        protected override void PerformTriggeredAction()
        {
            lucy.gameObject.SetActive(true);
            nextSequence.SetActive(true);
        }
    }
    
    [Serializable]
    public class UnityEventFirstKeySequence1 : UnityEvent<FirstKeySequence1> { }
}