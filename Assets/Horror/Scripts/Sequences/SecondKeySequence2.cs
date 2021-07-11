using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class SecondKeySequence2 : MonoBehaviour
    {
        #region Inspector



        #endregion

        [Inject(Id = "key")]
        private ItemInteractable key = null;

        [Inject(Id = "library.standing")]
        private Transform libraryStanding = null;

        [Inject(Id = "library.fallen")]
        private Transform libraryFallen = null;

        [Inject(Id = "coatrack")]
        private Transform coatRack = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject]
        private void Inject()
        {
            key.onInteraction.AddListener(OnKeyInteraction);
        }

        private void OnKeyInteraction()
        {
            key.onInteraction.RemoveListener(OnKeyInteraction);
            StartCoroutine(SequenceCoroutine());
        }

        private IEnumerator SequenceCoroutine()
        {
            coatRack.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            libraryStanding.gameObject.SetActive(false);
            libraryFallen.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            lucy.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventSecondKeySequence2 : UnityEvent<SecondKeySequence2> { }
}