using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Actuators
{
    [RequireComponent(typeof(IMovementActuator))]
    public class MovementActuatorDirectionInjector : MonoBehaviour
    {
        #region Inspector

        private void Reset()
        {
            GetComponent<IMovementActuator>().DirectionReference = null;
        }

        #endregion

        [Inject]
        private void Inject([Inject(Id = "player.camera")] Transform playerCamera)
        {
            GetComponent<IMovementActuator>().DirectionReference = playerCamera;
            Destroy(this);
        }
    }
}