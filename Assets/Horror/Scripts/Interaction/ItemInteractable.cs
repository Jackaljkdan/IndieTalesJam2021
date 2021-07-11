using DG.Tweening;
using JK.Interaction;
using JK.Sounds;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Interaction
{
    public class ItemInteractable : InteractableBehaviour
    {
        #region Inspector

        public string id;

        public float behindCameraMultiplier = 1f;

        public Vector3 behindCameraOffset = new Vector3(0, -0.2f, 0);

        public float moveLerp = 0.2f;

        public UnityEvent onInteraction = new UnityEvent();

        [SerializeField]
        private new Collider collider = null;

        #endregion

        [Inject]
        private Inventory inventory = null;

        [Inject(Id = "player.camera")]
        private Transform cameraTransform = null;

        protected override void PerformInteraction(RaycastHit hit)
        {
            collider.enabled = false;

            inventory.items.Add(id);

            if (TryGetComponent(out RandomClipsPlayer player))
                player.PlayRandom();

            StartCoroutine(MoveToCameraCoroutine());

            onInteraction.Invoke();
        }

        private IEnumerator MoveToCameraCoroutine()
        {
            Transform tr = transform;

            Vector3 target;

            do
            {
                target = GetTargetPosition();
                tr.position = Vector3.Lerp(tr.position, target, moveLerp);
                //tr.localScale = Vector3.Lerp(tr.localScale, Vector3.zero, moveLerp);
                yield return null;
            }
            while ((tr.position - target).sqrMagnitude > 0.4f);
            
            transform.SetParent(cameraTransform);

            yield return new WaitForSeconds(5);

            Destroy(gameObject);
        }

        private Vector3 GetTargetPosition()
        {
            Vector3 target = cameraTransform.position - cameraTransform.forward * behindCameraMultiplier;
            target += behindCameraOffset;

            return target;
        }
    }

    [Serializable]
    public class UnityEventItemInteractable : UnityEvent<ItemInteractable> { }
}