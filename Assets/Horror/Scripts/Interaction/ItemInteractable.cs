using DG.Tweening;
using JK.Interaction;
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

        public float moveLerp = 0.2f;

        public AudioClip clip;

        #endregion

        [Inject]
        private Inventory inventory = null;

        [Inject(Id = "player.camera")]
        private Transform cameraTransform = null;

        protected override void PerformInteraction(RaycastHit hit)
        {
            GetComponent<Collider>().enabled = false;

            inventory.items.Add(id);

            if (clip != null && TryGetComponent(out AudioSource audioSource))
                audioSource.PlayOneShot(clip);

            StartCoroutine(MoveToCameraCoroutine());
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
            gameObject.SetActive(false);
        }

        private Vector3 GetTargetPosition()
        {
            Vector3 target = cameraTransform.position - cameraTransform.forward * 0.5f;
            target.y -= 0.2f;

            return target;
        }
    }

    [Serializable]
    public class UnityEventItemInteractable : UnityEvent<ItemInteractable> { }
}