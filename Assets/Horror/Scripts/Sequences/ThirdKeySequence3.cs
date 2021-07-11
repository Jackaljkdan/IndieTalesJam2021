using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class ThirdKeySequence3 : TriggeredAction
    {
        #region Inspector

        public LightSwitchInteractable bajour;

        #endregion

        [Inject]
        private ThirdKeySequence2 secondSequence = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject(Id = "coatrack")]
        private Transform coatRack = null;

        private void Start()
        {
            secondSequence.onFinished.AddListener(OnSecondSequenceFinished);
        }

        private void OnSecondSequenceFinished()
        {
            bajour.onInteraction.AddListener(OnBajourInteracted);
        }

        private void OnBajourInteracted()
        {
            PerformTriggeredAction();
            Destroy(gameObject);
        }

        protected override void PerformTriggeredAction()
        {
            Destroy(lucy.gameObject);
            coatRack.gameObject.SetActive(true);
        }
    }
    
    [Serializable]
    public class UnityEventThirdKeySequence3 : UnityEvent<ThirdKeySequence3> { }
}