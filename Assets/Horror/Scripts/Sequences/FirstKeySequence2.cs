using DG.Tweening;
using Horror.Interaction;
using JK.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class FirstKeySequence2 : TriggeredAction
    {
        #region Inspector

        [SerializeField]
        private LightSwitchInteractable bajour = null;

        [SerializeField]
        private LightTargetBehaviour task = null;

        [SerializeField]
        private GameObject nextSequence = null;

        #endregion

        [Inject]
        private Worker worker = null;

        [Inject(Id = "music")]
        private AudioSource music = null;

        protected override void PerformTriggeredAction()
        {
            worker.StartCoroutine(SequenceCoroutine());
        }

        private IEnumerator SequenceCoroutine()
        {
            nextSequence.SetActive(true);

            if (bajour.lightTarget.IsOn)
                bajour.Interact(new RaycastHit());

            music.DOFade(0, 0.3f);

            yield return new WaitForSeconds(1);

            task.Toggle();
        }
    }
    
    [Serializable]
    public class UnityEventFirstKeySequence2 : UnityEvent<FirstKeySequence2> { }
}