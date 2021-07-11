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
    [RequireComponent(typeof(Animator))]
    public class LockInteractable : InteractableBehaviour
    {
        #region Inspector

        public string keyId;

        public GameObject key;

        #endregion

        [Inject]
        private Inventory inventory = null;

        protected override void Start()
        {
            base.Start();
            key.SetActive(false);
        }

        protected override void PerformInteraction(RaycastHit hit)
        {
            if (!inventory.items.Contains(keyId))
                return;

            //Debug.Log("unlocking");
            key.SetActive(true);
            GetComponent<Animator>().Play("Unlock");
        }

        public void OnUnlockSound()
        {
            //Debug.Log("unlock sound");

            if (TryGetComponent(out RandomClipsPlayer player))
                player.PlayRandom();
        }

        public void OnUnlockEnd()
        {
            //Debug.Log("done unlocking");
            key.SetActive(false);
        }

        public void OnMeldEnd()
        {
            Destroy(gameObject);
        }
    }
    
    [Serializable]
    public class UnityEventLockInteractable : UnityEvent<LockInteractable> { }
}