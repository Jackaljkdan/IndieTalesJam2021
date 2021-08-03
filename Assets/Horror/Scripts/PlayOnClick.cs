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
        private Transform playerCamera = null;

        [Inject(Id = "player")]
        private Transform player = null;

        [Inject]
        private CanvasGroup ui = null;
        
        private void Start()
        {
            playerCamera.GetComponent<RotationActuatorInputBehaviour>().enabled = false;
            player.GetComponent<MovementActuatorInputBehaviour>().enabled = false;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetAxis("Fire1") == 1)
            {
                playerCamera.GetComponent<RotationActuatorInputBehaviour>().enabled = true;
                player.GetComponent<MovementActuatorInputBehaviour>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;

                CanvasGroup justInCase = ui;
                justInCase.DOFade(0, 0.5f).onComplete += () => justInCase.gameObject.SetActive(false);

                Destroy(this);
            }
        }
    }
}