using Horror.Interaction;
using Horror.Lucy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    public class ThirdKeySequence2 : TriggeredAction
    {
        #region Inspector

        [SerializeField]
        private List<LightSwitchInteractable> bajours = null;

        public UnityEvent onFinished = new UnityEvent();

        #endregion

        [Inject]
        private ThirdKeySequence1 firstSequence = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        protected override void PerformTriggeredAction()
        {
            if (firstSequence != null)
            {
                firstSequence.gameObject.SetActive(false);
                Destroy(firstSequence);
            }

            StartCoroutine(SequenceCoroutine());
        }

        private IEnumerator SequenceCoroutine()
        {
            lucy.GetComponent<LucyBreathing>().enabled = true;

            foreach (var bajour in bajours)
            {
                if (bajour.lightTarget.IsOn)
                    bajour.Interact(new RaycastHit());

                yield return new WaitForSeconds(0.4f);
            }

            onFinished.Invoke();

            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventThirdKeySequence2 : UnityEvent<ThirdKeySequence2> { }
}