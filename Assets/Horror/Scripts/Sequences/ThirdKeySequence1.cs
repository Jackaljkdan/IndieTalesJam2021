using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Horror.Sequences
{
    public class ThirdKeySequence1 : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private List<LightSwitchInteractable> bajours = null;

        #endregion

        private void Start()
        {
            bajours[0].onInteraction.AddListener(OnFirstBajourInteracted);
        }

        private void OnFirstBajourInteracted()
        {
            bajours[0].onInteraction.RemoveListener(OnFirstBajourInteracted);
            StartCoroutine(TurnOnAllBajoursCoroutine());
        }

        private IEnumerator TurnOnAllBajoursCoroutine()
        {
            for (int i = 1; i < bajours.Count; i++)
            {
                yield return new WaitForSeconds(1);
                bajours[i].Interact(new RaycastHit());
            }

            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventThirdKeySequence1 : UnityEvent<ThirdKeySequence1> { }
}