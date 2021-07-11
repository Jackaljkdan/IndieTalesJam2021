using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Horror.Attention
{
    public class ForceCameraLook : MonoBehaviour
    {
        #region Inspector

        public float lerp = 2;

        public Vector3 offset;

        #endregion

        public class Factory : PlaceholderFactory<ForceCameraLook> { }
        
        [Inject(Id = "player.camera")]
        private Transform cameraTransform = null;

        private void LateUpdate()
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.position + offset - cameraTransform.position, Vector3.up);

            // N.B. we can't simply use the following because it rotates also on the z axis
            //cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, lerp * Time.deltaTime);

            Vector3 targetEuler = targetRotation.eulerAngles;
            Vector3 euler = cameraTransform.eulerAngles;

            float lerpTime = lerp * Time.deltaTime;
            Vector3 lerpEuler = new Vector3(
                Mathf.LerpAngle(euler.x, targetEuler.x, lerpTime),
                Mathf.LerpAngle(euler.y, targetEuler.y, lerpTime),
                0
            );

            cameraTransform.eulerAngles = lerpEuler;
        }

    }
    
    [Serializable]
    public class UnityEventForceCameraLook : UnityEvent<ForceCameraLook> { }
}