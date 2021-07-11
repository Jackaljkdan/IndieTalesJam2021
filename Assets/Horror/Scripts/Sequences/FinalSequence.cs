using DG.Tweening;
using Horror.Actuators.Input;
using Horror.Attention;
using Horror.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Sequences
{
    [RequireComponent(typeof(AudioSource))]
    public class FinalSequence : MonoBehaviour
    {
        #region Inspector



        #endregion

        [Inject]
        private List<UnlockDoorWhenLocksDestroyed> unlockers = null;

        [Inject(Id = "music")]
        private AudioSource music = null;

        [Inject]
        private DoorInteractable door = null;

        [Inject(Id = "lucy")]
        private Transform lucy = null;

        [Inject(Id = "player.camera")]
        private RotationActuatorAxisInput inputRotation = null;

        [Inject(Id = "player")]
        private MovementActuatorAxisInput inputMovement = null;

        private void Start()
        {
            foreach (var un in unlockers)
                un.onDoorUnlock.AddListener(OnDoorUnlock);

            door.onInteraction.AddListener(OnDoorInteracted);
        }

        private void OnDoorUnlock()
        {
            foreach (var un in unlockers)
                if (un != null)
                    un.onDoorUnlock.RemoveListener(OnDoorUnlock);

            music.DOFade(0, 0.3f);
        }

        private void OnDoorInteracted()
        {
            if (door.IsAnimating)
                StartCoroutine(SequenceCoroutine());
        }

        private IEnumerator SequenceCoroutine()
        {
            yield return new WaitForSeconds(1);

            lucy.gameObject.SetActive(true);
            lucy.GetComponent<ForceCameraLook>().enabled = true;

            inputRotation.enabled = false;
            inputMovement.enabled = false;

            GetComponent<AudioSource>().Play();
        }
    }
    
    [Serializable]
    public class UnityEventFinalSequence : UnityEvent<FinalSequence> { }
}