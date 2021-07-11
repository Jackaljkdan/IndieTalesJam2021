using DG.Tweening;
using Horror.Actuators.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror
{
    public class PlayOnClick : MonoBehaviour
    {
        #region Inspector

        #endregion

        [Inject(Id = "player.camera")]
        private RotationActuatorAxisInput inputRotation = null;

        [Inject(Id = "player")]
        private MovementActuatorAxisInput inputMovement = null;

        [Inject]
        private CanvasGroup ui = null;
        
        [Inject]
        private void Inject()
        {
            inputRotation.enabled = false;
            inputMovement.enabled = false;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetAxis("Fire1") == 1)
            {
                inputRotation.enabled = true;
                inputMovement.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;

                CanvasGroup justInCase = ui;
                justInCase.DOFade(0, 0.5f).onComplete += () => justInCase.gameObject.SetActive(false);

                Destroy(this);
            }
        }
    }
}