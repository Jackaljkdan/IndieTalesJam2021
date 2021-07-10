using DG.Tweening;
using JK.Interaction;
using JK.World;
using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Interaction
{
    public class DrawerInteractable : InteractableBehaviour
    {
        #region Inspector

        public Vector3 delta = new Vector3(0, 0, -3);

        public float animSeconds = 1;

        [Header("Internals")]

        [SerializeField]
        private Collider front = null;

        private void Reset()
        {
            if (front == null)
                Debug.LogWarning("remember to assign front");
        }

        #endregion

        public bool IsClosed => Mathf.Approximately((closedLocalPosition - transform.localPosition).sqrMagnitude, 0);

        private Vector3 closedLocalPosition;
        private Tween tween;

        [Inject]
        private void Inject()
        {
            closedLocalPosition = transform.localPosition;
        }

        protected override void PerformInteraction(RaycastHit hit)
        {
            if (tween != null)
                tween.Kill();

            if (IsClosed)
                tween = transform.DOLocalMove(closedLocalPosition + delta, animSeconds).SetUpdate(UpdateType.Fixed);
            else
                tween = transform.DOLocalMove(closedLocalPosition, animSeconds).SetUpdate(UpdateType.Fixed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (tween != null)
                tween.Kill();
        }
    }
    
    [Serializable]
    public class UnityEventDrawerInteractable : UnityEvent<DrawerInteractable> { }
}