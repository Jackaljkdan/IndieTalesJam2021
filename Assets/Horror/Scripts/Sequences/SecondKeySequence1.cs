using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class SecondKeySequence1 : TriggeredAction
    {
        #region Inspector



        #endregion

        [Inject]
        private RadioInteractable radio = null;

        [Inject]
        private FlickeringLight flickering = null;

        protected override void PerformTriggeredAction()
        {
            radio.Interact(new RaycastHit());
            flickering.enabled = true;
            flickering.StartFlicker();
        }
    }
    
    [Serializable]
    public class UnityEventSecondKeySequence1 : UnityEvent<SecondKeySequence1> { }
}