using DG.Tweening;
using Horror.Interaction;
using Horror.Lucy;
using JK.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class FirstKeySequence3 : TriggeredAction
    {
        #region Inspector

        public UnityEvent onFinished = new UnityEvent();

        #endregion

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject]
        private Worker worker = null;

        [Inject(Id = "music")]
        private AudioSource music = null;

        [Inject(Id = "coatrack")]
        private Transform coatRack = null;

        protected override void PerformTriggeredAction()
        {
            worker.StartCoroutine(SequenceCoroutine());
        }

        private IEnumerator SequenceCoroutine()
        {
            var lucyBreathingSource = lucy.GetComponent<LucyBreathing>().breathingPlayer.AudioSource;
            yield return lucyBreathingSource.DOFade(0, 0.25f).WaitForCompletion();

            lucy.gameObject.SetActive(false);
            coatRack.gameObject.SetActive(true);

            music.DOFade(1, 1);

            onFinished.Invoke();

            Destroy(gameObject);
        }
    }
}