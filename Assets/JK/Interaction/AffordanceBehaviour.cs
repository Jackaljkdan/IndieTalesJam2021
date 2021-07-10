using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JK.Interaction
{
    public abstract class AffordanceBehaviour : MonoBehaviour, IAffordance
    {
        #region Inspector



        #endregion

        public bool IsHighlighting { get; private set; }

        // declare a start method so that the monobehaviour can be disabled in in the inspector if needed
        protected virtual void Start() { }

        public void Highlight(RaycastHit hit)
        {
            if (!IsHighlighting)
            {
                StartHighlight(hit);
                IsHighlighting = true;
                return;
            }
            else
            {
                StayHighlight(hit);
                CancelInvoke(nameof(OnStoppedRaycasting));
                Invoke(nameof(OnStoppedRaycasting), 0.016f);
            }
        }

        private void OnStoppedRaycasting()
        {
            StopHighlight();
            IsHighlighting = false;
        }

        protected abstract void StartHighlight(RaycastHit hit);
        protected abstract void StayHighlight(RaycastHit hit);
        protected abstract void StopHighlight();
    }
    
    [Serializable]
    public class UnityEventAffordanceBehaviour : UnityEvent<AffordanceBehaviour> { }
}