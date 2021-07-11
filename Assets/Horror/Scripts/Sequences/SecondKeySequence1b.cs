using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class SecondKeySequence1b : TriggeredAction
    {
        #region Inspector



        #endregion

        [Inject]
        private RadioInteractable radio = null;

        protected override void PerformTriggeredAction()
        {
            radio.Interact(new RaycastHit());
        }
    }
    
    [Serializable]
    public class UnityEventSecondKeySequence1b : UnityEvent<SecondKeySequence1b> { }
}